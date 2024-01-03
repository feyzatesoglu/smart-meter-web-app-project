import { Component } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  isLoggedIn: boolean = false;
  userRole: string = '';

  constructor(private accountService: AccountService,private router : Router) {}

  ngOnInit() {
    this.accountService.isLoggedIn$.subscribe(status => {
      this.isLoggedIn = status;
    });

    this.accountService.userRole$.subscribe(role => {
      this.userRole = role;
    });
  }
  logOut() {
    this.accountService.logOut();
    this.router.navigate(['/anasayfa']);
    alert("Çıkış yapıldı");
  }
}

