import { Injectable } from '@angular/core';
import {  UserLogin } from '../models/UserLogin';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  isLoggedIn = new BehaviorSubject<boolean>(false);
  userRole = new BehaviorSubject<string>('user'); 
  private apiUrl = 'https://localhost:7069/api'; // Web API adresi

  constructor(private http: HttpClient) {
    const isLogged = localStorage.getItem('isLogged');
    if (isLogged) {
      this.isLoggedIn.next(isLogged === 'true');
    }

    const storedRole = localStorage.getItem('userRole');
    if (storedRole) {
      this.userRole.next(storedRole);
    }
  }

  setLoggedIn(status: boolean) {
    this.isLoggedIn.next(status);
    localStorage.setItem('isLogged', status ? 'true' : 'false');
  }

  setUserRole(role: string) {
    this.userRole.next(role);
    localStorage.setItem('userRole', role);
  }
// Default olarak bir kullanıcı rolü atadım, sizin projenize göre değişebilir.

  isLoggedIn$ = this.isLoggedIn.asObservable();
  userRole$ = this.userRole.asObservable();

 
  registerUser(userData: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/Auth/register`, userData);
  }


login(userLogin: UserLogin): Observable<any> {
  return this.http.post<any>(`${this.apiUrl}/Auth/login`, userLogin);
  
}




logOut(){
  this.setLoggedIn(false);
  this.setUserRole('user');
}

deleteUser(userId: number): Observable<any> {
  return this.http.delete<any>(`${this.apiUrl}/AuthAdmin/delete-user/${userId}`);
}

getUsers(): Observable<any[]> {
  return this.http.get<any[]>(`${this.apiUrl}/AuthAdmin/GetUsers`);
}
getUsersByType(type: string): Observable<any[]> {
  return this.http.get<any[]>(`${this.apiUrl}/AuthAdmin/GetType/${type}`);
}

updatePassword(updatePasswordData: any): Observable<any> {
  return this.http.post<any>(`${this.apiUrl}/Auth/update-password`, updatePasswordData);
}

resetPassword(resetPasswordData : any): Observable<any> {
  return this.http.post<any>(`${this.apiUrl}/Auth/forget-password`,resetPasswordData); // Sunucu tarafındaki ilgili endpoint URL'si

  
}
}
 

  


