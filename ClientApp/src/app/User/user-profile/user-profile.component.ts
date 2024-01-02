import { Component } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { AlertifyService } from 'src/app/Services/alertify.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent {

  constructor(
    
    private accountService: AccountService ,// Inject your AccountService here
    private alertify: AlertifyService
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


}
