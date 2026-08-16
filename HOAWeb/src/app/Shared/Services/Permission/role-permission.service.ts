import { Injectable } from '@angular/core';
import { LocalStorageService } from '../LocalStorage/local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class RolePermissionService {
  private userRoles: string[] = []; // Array to hold the user's roles

constructor(private _localStorageService:LocalStorageService) 
{  
  var userDetails = _localStorageService.getData("LoggedInUserDetails");
  this.userRoles= userDetails.message.userRole;
}

 IsAuthroized=false;
hasRole(role: string): boolean 
{ 
  if(this.userRoles.includes('Admin'))
  {
    this.IsAuthroized=true;
  }
  else
  {
    this.IsAuthroized= this.userRoles.includes(role);
  }
  return this.IsAuthroized;
}


}
