import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(public http: HttpClient) { }

  loginUser(model) {
    return this.http.get('assets/api/user/users.json', model)
    .toPromise();
  }
}
