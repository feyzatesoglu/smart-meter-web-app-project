import { Component } from '@angular/core';
import { ShowFormService } from 'src/app/Services/show-form.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent {
  constructor(public showFormService:ShowFormService){}
  toggleKayitFormuGoster(index:number) {
    this.showFormService.toggleKayitFormuGoster(index);
  }
}
