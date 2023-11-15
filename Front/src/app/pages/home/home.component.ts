import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UsuarioService } from 'src/app/services/usuario.service';
import { environment } from 'src/environments/environment';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { iUsuarioFull } from 'src/app/interfaces/IUsuario';

const apiUrlUsuario = environment.apiUrl;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  formEdit: FormGroup;

  listGridUsuario: Array<any> = [];
  isNew: boolean = false;
  dadosParaEditar = {};
  formUsuario: FormGroup;



  constructor(private httpClient: HttpClient,private snackBar: MatSnackBar,private formBuilder: FormBuilder,
    private usuarioService: UsuarioService){}
  

  ngOnInit(): void {
    this.ConsultarGridUsuario();
    this.criarformEdit();
  }

  criarformEdit(){
    
    this.formUsuario = this.formBuilder.group({
      idUsuario:['', [Validators.nullValidator]],
      nome: ['', [Validators.required]],
      cpf: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required]],
      telefone: ['', [Validators.required]],
      cep: ['', [Validators.required]],
      rua: ['', [Validators.required]],
      numero: ['', [Validators.required]],
      bairro: ['', [Validators.required]],
      cidade: ['', [Validators.required]],
      estado: ['', [Validators.required]]
    });
    
  }

  Editar(id: number){
    this.isNew = false;
    //Resetar formulario


    this.ConsultarPorId(id);
  
  }

  Novo(){
    this.isNew = true;
    this.formUsuario.reset();
    //Resetar formulario
  }

  ConsultarGridUsuario(){   
    this.httpClient.get<any>(environment.apiUrl + "Usuario/ConsultarGridUsuario").subscribe(
      (resposta: any) => {
        if(!resposta.sucesso){
          this.snackBar.open('Falha ao cadastrar', resposta.mensagem, {
            duration: 3000
          });
        }
        else{
          resposta.data.itens.forEach(element => {
            this.listGridUsuario.push(element);
          });
        };        
      });
  }

  Salvar(){
   
    if(this.isNew){
      //Salvar usuario
      if(this.formUsuario.invalid) return;

      var usuarioCadastro = this.formUsuario.getRawValue() as iUsuarioFull;
      this.usuarioService.cadastroFull(usuarioCadastro).subscribe((response) => {
          if(!response.sucesso){
            this.snackBar.open('Falha ao cadastrar', response.mensagem, {
              duration: 3000
            });
          }else{
            this.formUsuario.reset();
            this.listGridUsuario = [];
            this.ConsultarGridUsuario();
            this.snackBar.open('Registro salvo com sucesso!', response.mensagem, {
              duration: 3000
            });
          }
      })
    }else{
      debugger
      if(this.formUsuario.invalid) return;

      var usuarioCadastro = this.formUsuario.getRawValue() as iUsuarioFull;
      this.usuarioService.editar(usuarioCadastro).subscribe((response) => {
          if(!response.sucesso){
            this.snackBar.open('Falha ao cadastrar', response.mensagem, {
              duration: 3000
            });
          }else{
            this.formUsuario.reset();
            this.listGridUsuario = [];
            this.ConsultarGridUsuario();
            this.snackBar.open('Registro salvo com sucesso!', response.mensagem, {
              duration: 3000
            });
          }
      })
    }
  }

  ConsultarPorId(id: number){
    this.httpClient.get<any>(environment.apiUrl + "Usuario/ConsultarViaId/" + id.toString()).subscribe(
      (resposta: any) => {
        if(!resposta.sucesso){
          this.snackBar.open('Falha ao consultar', resposta.mensagem, {
            duration: 3000
          });
        }
        else{
          
          this.formUsuario.patchValue(resposta.data);
        };        
      });
  }
}
