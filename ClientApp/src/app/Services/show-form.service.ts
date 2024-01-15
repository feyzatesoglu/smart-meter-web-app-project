import { Injectable } from '@angular/core';
import { UserTypeService } from './userType.service';

@Injectable({
  providedIn: 'root'
})
export class ShowFormService {

  constructor(private userTypeService: UserTypeService) { }
  kayitFormuGoster: boolean[] = [false, false, false]; // Her buton için bir boolean değer saklayacak dizi

  toggleKayitFormuGoster(index: number, userType:string) {
    console.log(`Button clicked with user type: ${userType}`);
    this.kayitFormuGoster[index] = !this.kayitFormuGoster[index];
    this.selectUserType(userType);
  }
  private selectUserType(userType: string) {
    // Your existing logic for handling user type
    console.log(`Selected user type: ${userType}`);
    this.userTypeService.setSelectedUserType(userType);
  }
}
