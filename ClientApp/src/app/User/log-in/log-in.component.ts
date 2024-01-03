import { Component } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { AlertifyService } from 'src/app/Services/alertify.service';
import { UserLogin } from 'src/app/models/UserLogin';
import { Router } from '@angular/router';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent {
  userLogin: UserLogin = { email: '', password: '' };

  constructor(private accountService: AccountService,
    private alertify: AlertifyService,
    private router: Router) {}

    login() {
      this.accountService.login(this.userLogin)
        .subscribe(
          (response: any) => {
            if (response && response.token) {
              this.alertify.success("Giriş başarılı");
              console.log(response);
              console.log(response.token);
              // Token'i yerel depoya kaydetme veya başka işlemler yapma
              localStorage.setItem('token', response.token);
    
              // Kullanıcı türüne göre yönlendirme
              if (response.userType === 'Admin') {
                this.redirectToAdmin();
              } else if (response.userType === 'User') {
                this.redirectToUser();
              }
            } else {
              this.alertify.error("Geçersiz giriş bilgileri");
            }
          },
          (error) => {
            this.alertify.error("Giriş başarısız" + error);
            // Hata durumunu işle, kullanıcıya bir bildirim göster veya başka bir işlem yap
          }
        );
    }
    
    redirectToAdmin() {
      this.accountService.setLoggedIn(true);
      this.accountService.setUserRole('Admin');
      this.router.navigate(['/admin']);
    }
    
    redirectToUser() {
      this.accountService.setLoggedIn(true);
      this.accountService.setUserRole('User');
      this.router.navigate(['/anasayfa']);
    }
}
