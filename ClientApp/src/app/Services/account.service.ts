import { Injectable } from '@angular/core';
import { User } from '../User/log-in/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
loggedIn=false;
login(user:User):boolean{
  if(user.userName=="feyza"&& user.password=="12345"){
    return true;
    this.loggedIn=true;
    localStorage.setItem("isLogged",user.userName);
  }
  return false;
}

isLoggedIn(){
  return this.loggedIn;
}

logOut(){
  localStorage.removeItem("isLogged");
  this.loggedIn=false;
}
}

