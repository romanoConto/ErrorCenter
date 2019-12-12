import { Component, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model = {
    mail: '',
    password: ''
  }

  constructor(public loginService : LoginService) { }

  ngOnInit() {
  }

  login() {
    this.loginService.loginUser(this.model).then(result => {
      console.log(result)
    });
  }
}
