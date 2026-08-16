import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './Shared/Services/AuthService/auth.service';

@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanActivate {

  
  constructor(private authService: AuthService, private router: Router) {}
  authresult:boolean=false;
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

 var result=
     this.authService.isAuthenticated().then(
          (response) => {
     if(response.message.split(':')[0]=="Success")
     {this.authresult= true;} 
    else {this.authresult= false;}
   }
   )
         
    if (this.authresult) 
    {return true;} else {this.router.navigate(['/']); return false;}
  }
}
