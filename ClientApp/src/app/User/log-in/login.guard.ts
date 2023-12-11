import { ActivatedRouteSnapshot, CanActivateChildFn, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Injectable, inject } from "@angular/core";
import { AccountService } from "src/app/Services/account.service";
import { Observable } from "rxjs";

export const AuthGuard: CanActivateFn = (
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    Observable<boolean | UrlTree> 
    | Promise<boolean | UrlTree> 
    | boolean 
    | UrlTree=> {
  
    return inject(AccountService).isLoggedIn()
      ? true
      : inject(Router).createUrlTree(['giris-yap']);
  
  };