import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(public http: HttpClient) { }

  createUser(model) {
    // depois mudar o get para o post para {baseURL}/api/user passando o objeto de criação
    return this.http.get('assets/api/user/createUserResponse.json', model)
    .toPromise();
  }
}
