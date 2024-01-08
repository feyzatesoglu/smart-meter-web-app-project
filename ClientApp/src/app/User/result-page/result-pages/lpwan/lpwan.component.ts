import { Component } from '@angular/core';
import { DataService } from 'src/app/Services/data.service';

@Component({
  selector: 'app-lpwan',
  templateUrl: './lpwan.component.html',
  styleUrls: ['./lpwan.component.css']
})
export class LpwanComponent {
  bilgiler: any[] | undefined;

  constructor(private dataService: DataService) { }

  incele() {
    this.bilgiler = this.dataService.getLpwanBilgiler();
  }
}
