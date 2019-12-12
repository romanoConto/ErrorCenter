import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../services/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  model = {
    name: '',
    mail: '',
    password: ''
  }

  constructor(public registerService : RegisterService) { }

  ngOnInit() {
  }

  create() {
    this.registerService.createUser(this.model).then(( )=> {
      console.log("Usuário Cadastrado com sucesso");
      // mudar a rota aqui
    });

  }
}
