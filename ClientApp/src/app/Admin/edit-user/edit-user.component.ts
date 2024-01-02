import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent {

  model: any= {
  };  // two-way binding

  saveUser(){
   console.log(this.model);
 }

}
