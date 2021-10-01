import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../services/alertify.service';

@Component({
  selector: 'nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
})
export class NavBarComponent implements OnInit {

  loggedInUser!: string | undefined;

  constructor(private alertifyService: AlertifyService) {}

  ngOnInit(): void {}

  loggedIn(){
    this.loggedInUser = localStorage.getItem('token')?.toString();
    return this.loggedInUser;
  }

  onLogout(){
    localStorage.removeItem('token');
    this.alertifyService.success('You logged out successfully')
  }
}
