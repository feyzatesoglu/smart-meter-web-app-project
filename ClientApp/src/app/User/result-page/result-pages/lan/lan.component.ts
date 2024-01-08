import { Component } from '@angular/core';
import { DataService } from 'src/app/Services/data.service';

@Component({
  selector: 'app-lan',
  templateUrl: './lan.component.html',
  styleUrls: ['./lan.component.css']
})
export class LanComponent {

  bilgiler: any[] | undefined;

  constructor(private dataService: DataService) { }

  incele() {
    this.bilgiler = this.dataService.getLanBilgiler();
  }
}
