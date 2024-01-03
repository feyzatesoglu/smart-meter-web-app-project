import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/Services/account.service';
import { AlertifyService } from 'src/app/Services/alertify.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent {
  ngOnInit(): void {
    this.getUserProfile();
  }
  constructor(
    
    private accountService: AccountService ,// Inject your AccountService here
    private alertify: AlertifyService,
    private router: Router
  ){}
  updatePasswordData = {
    currentPassword: '',
    newPassword: ''
  };
  onUpdatePassword(): void {
    this.accountService.updatePassword(this.updatePasswordData)
      .subscribe(
        response => {
          console.log('Password updated successfully', response);
          // Başarılı cevap durumunda burada yapılacak işlemler
        },
        error => {
          console.error('Failed to update password', error);
          // Hata durumunda burada yapılacak işlemler
        }
      );
  }
  userProfile: any;

  

  logOut() {
    this.accountService.logOut();
    this.router.navigate(['/anasayfa']);
    alert("Çıkış yapıldı");
  }

  getUserProfile() {
    this.accountService.getUserProfile().subscribe(
      (data) => {
        this.userProfile = data;
        console.log(this.userProfile);
      },
      (error) => {
        console.error(error);
      }
    );
  }

}
