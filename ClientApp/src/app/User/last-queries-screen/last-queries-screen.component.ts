import { Component } from '@angular/core';
import { QueryService } from 'src/app/Services/query.service';
import { AccountService } from 'src/app/Services/account.service';

@Component({
  selector: 'app-last-queries-screen',
  templateUrl: './last-queries-screen.component.html',
  styleUrls: ['./last-queries-screen.component.css']
})
export class LastQueriesScreenComponent {

  userId: number = 4; // Replace with the actual user ID
  predictionResult: any;
  userProfile: any;

  constructor(private queryService: QueryService, private accountService: AccountService) { }

  ngOnInit() {
    this.getUserProfile();
  }

  getUserProfile() {
    this.accountService.getUserProfile().subscribe(
      (data) => {
        this.userProfile = data;
        console.log(this.userProfile);
        this.getPrediction(this.userProfile.id); // Call getPrediction here
      },
      (error) => {
        console.error(error);
      }
    );
  }

  getPrediction(userId: number) {
    this.queryService.getPrediction(userId)
      .subscribe(
        (result) => {
          this.predictionResult = result;
          console.log('Prediction result:', this.predictionResult);
          // Handle the result as needed
        },
        (error) => {
          console.error('Error fetching prediction:', error);
          // Handle errors
        }
      );
  }
}
