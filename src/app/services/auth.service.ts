import { Injectable } from '@angular/core';
import { User } from '../model/user';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor() {}

  authUser(user: User) {
    let userArray: any[] = [];
    if (localStorage.getItem('Users')) {
      userArray = JSON.parse(localStorage.getItem('Users')!);
    }
    console.log(userArray);
    return userArray.find(
      (p: User) => p.userName === user.userName && p.password === user.password
    );
  }
}
