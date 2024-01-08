import { Component } from '@angular/core';
import { DataService } from 'src/app/Services/data.service';

@Component({
  selector: 'app-satellite',
  templateUrl: './satellite.component.html',
  styleUrls: ['./satellite.component.css']
})
export class SatelliteComponent {
  bilgiler: any[] | undefined;

  constructor(private dataService: DataService) { }

  incele() {
    this.bilgiler = this.dataService.getSatelliteBilgiler();
  }
}
