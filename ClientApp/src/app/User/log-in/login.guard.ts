import { ActivatedRouteSnapshot, CanActivate, CanActivateChildFn, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Injectable, inject } from "@angular/core";
import { AccountService } from "src/app/Services/account.service";
import { Observable, map, take } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private accountService: AccountService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.accountService.isLoggedIn$.pipe(
      take(1), // Sadece bir kez dinlemek için take operatörü
      map(isLoggedIn => {
        if (isLoggedIn) {
          return true; // Kullanıcı giriş yapmışsa izin ver
        } else {
          return this.router.createUrlTree(['giris-yap']); // Giriş yapılmamışsa login sayfasına yönlendir
        }
      })
    );
  }
}