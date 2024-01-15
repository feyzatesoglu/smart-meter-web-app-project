// user-type.service.ts

import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserTypeService {
  private selectedUserTypeSubject = new BehaviorSubject<string>('');
  selectedUserType$ = this.selectedUserTypeSubject.asObservable();

  setSelectedUserType(userType: string) {
    this.selectedUserTypeSubject.next(userType);
  }
}