import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';

@Component({
  selector: 'app-forget-password',
  templateUrl: './forget-password.component.html',
  styleUrls: ['./forget-password.component.css']
})
export class ForgetPasswordComponent implements OnInit {


  constructor(private http: HttpClient,private accountService : AccountService) {}

  ngOnInit() {
    
  }
 
  resetPasswordData = {
    email: '',
    Password: ''
  };
  confirmPassword = '';


  resetPassword(): void {
    if (this.resetPasswordData.Password !== this.confirmPassword) {
      alert('Şifreler eşleşmiyor!');
      return;
    }

    this.accountService.resetPassword(this.resetPasswordData).subscribe(
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
