import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Pessoa } from '../../Pessoa';
import { PessoasService } from '../../pessoas.service';

@Component({
  selector: 'app-pessoas',
  templateUrl: './pessoas.component.html',
  styleUrl: './pessoas.component.css'
})
export class PessoasComponent implements OnInit {

  formulario: any
  titulo: string = '';

  constructor(private pessoaService: PessoasService) { }

  ngOnInit(): void {
    this.titulo = "Nova Pessoa"
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      sobrenome: new FormControl(null),
      idade: new FormControl(null),
      profissao: new FormControl(null)
    })
  }

  EnviarFormulario(): void {
    const pessoa: Pessoa = this.formulario.value;
    this.pessoaService.createPessoa(pessoa).subscribe((resultado) => { alert("OK") });
     
       
  }


}
