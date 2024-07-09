import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pessoa } from './Pessoa';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class PessoasService {
  url = 'https://localhost:7286/api/pessoas';

  constructor(private http: HttpClient) { }

  // Obter todas as pessoas
  getPessoas(): Observable<Pessoa[]> {
    return this.http.get<Pessoa[]>(this.url);
  }

  // Obter pessoa por ID
  getPessoaById(pessoaId: number): Observable<Pessoa> {
    const url = `${this.url}/${pessoaId}`; 
    return this.http.get<Pessoa>(url);
  }

  // Salvar pessoa
  createPessoa(pessoa: Pessoa): Observable<Pessoa> { 
    return this.http.post<Pessoa>(this.url, pessoa, httpOptions);
  }

  // Atualizar pessoa
  updatePessoa(pessoa: Pessoa): Observable<any> {
    const url = `${this.url}/${pessoa.PessoaId}`;
    return this.http.put(url, pessoa, httpOptions);
  }

  // Excluir pessoa
  deletePessoa(id: number): Observable<any> {
    const url = `${this.url}/${id}`;
    return this.http.delete(url, httpOptions);
  }
}
