import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User, UserForLogin } from '../model/user';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) {}

  authUser(user: UserForLogin) {
    return this.http.post(this.baseUrl + '/account/login', user);
    // let userArray: any[] = [];
    // if (localStorage.getItem('Users')) {
    //   userArray = JSON.parse(localStorage.getItem('Users')!);
    // }
    // console.log(userArray);
    // return userArray.find(
    //   (p: User) => p.userName === user.userName && p.password === user.password
    // );
  }

  registerUser(user: User){
    return this.http.post(this.baseUrl + "/account/register", user);
  }
}
