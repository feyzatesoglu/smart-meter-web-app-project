import { Component, Output, EventEmitter } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { ShowFormService } from 'src/app/Services/show-form.service';

import { UserRegistration } from 'src/app/models/UserRegistration';
import { AlertifyService } from 'src/app/Services/alertify.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent {
  constructor(
    public showFormService: ShowFormService,
    private accountService: AccountService ,// Inject your AccountService here
    private alertify: AlertifyService
  ){}

  userData: UserRegistration = {
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    userType:"Normal",
    role: "User"
  };// Kullanıcı bilgilerini tutacak nesne

  confirmPassword: string = ''; // Parola tekrarını tutacak değişken
  acceptterms: boolean = false; // Kullanıcı sözleşmeyi kabul etti mi?
  onSubmit(): void {

    // Parola tekrarı doğru mu?
    if(this.userData.password !== this.confirmPassword){
      this.alertify.warning('Passwords do not match!');
      return;
    }
    //Accept terms işaretli mi?
    if(!this.acceptterms){
      this.alertify.warning('You must accept the terms!');
      return;
    }
    this.accountService.registerUser(this.userData)
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
