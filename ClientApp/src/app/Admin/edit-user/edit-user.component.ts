import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from 'src/app/Services/account.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {

  userId!: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService,
  ) { }
  model: any= {
  };  // two-way binding
  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.userId = +params['id'];
      this.accountService.getUpdateUserById(this.userId).subscribe(user => {
        this.model = user;
        console.log(user);
      });
    });


  }
  saveUser(): void {

    if (this.model.role == 'admin') {
      this.model.userType="Admin";

     
    }
    this.accountService.updateUser(this.userId, this.model).subscribe(() => {
      this.router.navigate(['/admin']);
    });
  }

}
