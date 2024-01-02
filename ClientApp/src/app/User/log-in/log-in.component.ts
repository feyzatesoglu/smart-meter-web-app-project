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
              // Token'i yerel depoya kaydetme veya başka işlemler yapma
              localStorage.setItem('token', response.token);
              // Örneğin, kullanıcı türüne göre yönlendirme yapabilirsiniz
              if (response.userType === 'Admin') {
                
                this.accountService.setLoggedIn(true);
                this.accountService.setUserRole(response.userType);
                this.router.navigate(['/admin']);
              } else if (response.userType === 'User') {
                this.accountService.setLoggedIn(true);
                this.accountService.setUserRole(response.userType);
                this.router.navigate(['/anasayfa']);
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
}
