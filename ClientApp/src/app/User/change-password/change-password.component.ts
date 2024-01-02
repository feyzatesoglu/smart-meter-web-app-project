import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import{AccountService} from '../../Services/account.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent {
 
  updatePasswordData = {
    email: '',
    oldPassword: '',
    newPassword: ''
  };
  confirmPassword = '';

  constructor(private http: HttpClient,private accountService : AccountService) {}

  updatePassword(): void {
    if (this.updatePasswordData.newPassword !== this.confirmPassword) {
      alert('Şifreler eşleşmiyor!');
      return;
    }

    this.accountService.updatePassword(this.updatePasswordData).subscribe(
      response => {
        alert("Şifre güncelleme başarılı");
        // Şifre güncelleme başarılı, gerekli işlemleri yapabilirsiniz
      },
      error => {
        alert("Şifre güncelleme başarısız");
        console.log(error);
        // Hata durumunda kullanıcıya bir hata mesajı gösterilebilir
      }
    );
  }
}

