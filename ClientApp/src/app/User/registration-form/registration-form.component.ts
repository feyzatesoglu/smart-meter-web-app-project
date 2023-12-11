import { Component, Output, EventEmitter } from '@angular/core';
import { ShowFormService } from 'src/app/Services/show-form.service';
@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent {
  constructor(public showFormService:ShowFormService){}
  userData: any = {}; // Kullanıcı bilgilerini tutacak nesne

}
