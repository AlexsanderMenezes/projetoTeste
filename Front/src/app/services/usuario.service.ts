import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IUsuario, iUsuarioCadastro, iUsuarioFull } from '../interfaces/IUsuario';

const apiUrlUsuario = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

constructor(private httpClient: HttpClient,
            private router: Router) { }

  logar(usuario: IUsuario) : Observable<any> {
  debugger;
    return this.httpClient.post<any>(apiUrlUsuario + "Auth/Login", usuario).pipe(
      tap((resposta) => {
        if(!resposta.sucesso) return;

        localStorage.setItem('token', resposta.data.sessionKey.token);
        localStorage.setItem('usuario', resposta.data.nome);

        this.router.navigate(['']);
      }));

  }

  cadastrase(usuarioCadastro: iUsuarioCadastro) : Observable<any> {
    debugger;
      return this.httpClient.post<any>(apiUrlUsuario + "Usuario/CadastroInicial", usuarioCadastro).pipe(
        tap((resposta) => {
          if(!resposta.sucesso) return;
        }));
  
    }

    cadastroFull(usuarioCadastro: iUsuarioFull) : Observable<any> {
      debugger;
        return this.httpClient.post<any>(apiUrlUsuario + "Usuario/Cadastrar", usuarioCadastro).pipe(
          tap((resposta) => {
            if(!resposta.sucesso) return;
          }));
    
      }

  editar(usuarioCadastro: iUsuarioFull) : Observable<any> {
    debugger;
      return this.httpClient.post<any>(apiUrlUsuario + "Usuario/Editar", usuarioCadastro).pipe(
        tap((resposta) => {
          if(!resposta.sucesso) return;
        }));
  
    }

  deslogar() {
      localStorage.clear();
      this.router.navigate(['login']);
  }

  get obterUsuarioLogado(): IUsuario {
    return localStorage.getItem('usuario')
      ? JSON.parse(atob(localStorage.getItem('usuario')))
      : null;
  }

  get obterIdUsuarioLogado(): string {
    return localStorage.getItem('usuario')
      ? (JSON.parse(atob(localStorage.getItem('usuario'))) as IUsuario).id
      : null;
  }

  get obterTokenUsuario(): string {
    return localStorage.getItem('token')
      ? JSON.parse(atob(localStorage.getItem('token')))
      : null;
  }

  get logado(): boolean {
    return localStorage.getItem('token') ? true : false;
  }
}

