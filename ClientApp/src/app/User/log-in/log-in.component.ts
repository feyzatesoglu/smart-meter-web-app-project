import { Component } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { AlertifyService } from 'src/app/Services/alertify.service';
import { UserLogin } from 'src/app/models/UserLogin';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent {
  userLogin: UserLogin = { email: '', password: '' };

  constructor(private accountService: AccountService,
    private alertify: AlertifyService) {}

  login() {
    this.accountService.login(this.userLogin)
      .subscribe(response => {
        this.alertify.success("Giriş başarılı");
        // Gelen yanıtı işle, belki token'i yerel depoya kaydet
      },
      error => {
        this.alertify.error("Giriş başarısız");
        // Hata durumunu işle, kullanıcıya bir bildirim göster veya başka bir işlem yap
      }
      );
  }
}
