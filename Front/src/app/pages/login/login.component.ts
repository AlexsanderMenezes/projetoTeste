import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IUsuario, iUsuarioCadastro } from '../../interfaces/IUsuario';
import { UsuarioService } from '../../services/usuario.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  formLogin: FormGroup;
  formCadastro: FormGroup;
  cadastro: boolean = false;

  constructor(private formBuilder: FormBuilder,
              private usuarioService: UsuarioService,
              private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.criarForm();
    this.criarFormCadastro();
  }

  criarForm(){
    this.formLogin = this.formBuilder.group({
      EmailLogin: ['', [Validators.required, Validators.email]],
      SenhaLogin: ['', [Validators.required]]
    });
  }

  logar(){
    if(this.formLogin.invalid) return;

    var usuario = this.formLogin.getRawValue() as IUsuario;
    this.usuarioService.logar(usuario).subscribe((response) => {
        if(!response.sucesso){
          this.snackBar.open('Falha na autenticação', 'Usuário ou senha incorretos.', {
            duration: 3000
          });
        }
    })
  }

  criarFormCadastro(){
    this.formCadastro = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required]],
      cpf: ['', [Validators.required]],
      nome: ['', [Validators.required]]
    });
  }

  cadastrese(){
    if(this.formCadastro.invalid) return;

    var usuarioCadastro = this.formCadastro.getRawValue() as iUsuarioCadastro;
    this.usuarioService.cadastrase(usuarioCadastro).subscribe((response) => {
        if(!response.sucesso){
          this.snackBar.open('Falha ao cadastrar', response.mensagem, {
            duration: 3000
          });
        }else{
          this.formCadastro.reset();
          this.cadastro = false;
          this.snackBar.open('Cadastro realizado com sucesso!', response.mensagem, {
            duration: 3000
          });
          this.cadastro = false;
        }
    })
  }

  cadastre(){
    this.cadastro = !this.cadastro;
  }
}
