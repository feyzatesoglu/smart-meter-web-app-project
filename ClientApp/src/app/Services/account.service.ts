import { Injectable } from '@angular/core';
import {  UserLogin } from '../models/UserLogin';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {


  private apiUrl = 'https://localhost:7069/api/Auth'; // Web API adresi

  constructor(private http: HttpClient) {}

  registerUser(userData: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/register`, userData);
  }
loggedIn=false;
login(userLogin: UserLogin): Observable<any> {
  return this.http.post<any>(`${this.apiUrl}/login`, userLogin);
}


isLoggedIn(){
  return this.loggedIn;
}

logOut(){
  localStorage.removeItem("isLogged");
  this.loggedIn=false;
}
}

