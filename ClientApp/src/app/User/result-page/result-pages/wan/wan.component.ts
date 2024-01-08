import { Component } from '@angular/core';
import { DataService } from 'src/app/Services/data.service';

@Component({
  selector: 'app-wan',
  templateUrl: './wan.component.html',
  styleUrls: ['./wan.component.css']
})
export class WanComponent {

  bilgiler: any[] | undefined;

  constructor(private dataService: DataService) { }

  incele() {
    this.bilgiler = this.dataService.getWanBilgiler();
  }
}
