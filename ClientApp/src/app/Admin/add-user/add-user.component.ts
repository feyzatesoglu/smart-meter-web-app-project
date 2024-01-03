import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { AlertifyService } from 'src/app/Services/alertify.service';
import { UserRegistration } from 'src/app/models/UserRegistration';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent {
  constructor(
   
    private accountService: AccountService ,// Inject your AccountService here
    private alertify: AlertifyService
  ){}
  model: UserRegistration = {
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    userType:'',
    role: '',
  };// Kullanıcı bilgilerini tutacak nesne


  

  saveUser(){
    if(this.model.role=="Admin"){
      this.model.userType="Infinite";
    }
    console.log(this.model);
    this.accountService.registerUser(this.model)
      .subscribe(
        response  => {
         this.alertify.success("Kayıt başarılı");
         console.log(response);
          // Başarılı kayıt durumunda yapılacak işlemler
        },
        (error: HttpErrorResponse) => {
          if (error.status === 400 && error.error && error.error.errors) {
            const validationErrors = error.error.errors;
        
            Object.keys(validationErrors).forEach(field => {
              const fieldErrors = validationErrors[field];
              console.log(`${field} errors:`, fieldErrors);
              fieldErrors.forEach((errorMessage: string) => {
                this.alertify.error(errorMessage);
              });
              // Her bir alanın hata mesajlarını kullanıcıya göstermek için gerekli işlemleri yapabilirsiniz
            });
          } else {
            console.error('Registration error:', error);
            // Diğer hata durumlarını burada ele alabilirsiniz
          }
        }
        
      );
 }

}
