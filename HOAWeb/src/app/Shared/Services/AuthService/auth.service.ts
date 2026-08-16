import { Injectable } from '@angular/core';
import { LocalStorageService } from 'src/app/Shared/Services/LocalStorage/local-storage.service';
import { HeaderService } from 'src/app/Shared/Services/header/header.service';
import { APIUrlService } from 'src/app/Shared/Services/APIServiceLinks/apiurl.service';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private headers: HttpHeaders;  
  constructor(
     private http: HttpClient,private _APIUrlService:APIUrlService,
     private headerService:HeaderService,private _localstorageservice:LocalStorageService) 
  {this.headers = this.headerService.getHeaders();}




  isAuthenticated(): Promise<any> 
  {
      return new Promise((resolve, reject) => {
      this.http.get<any>(this._APIUrlService.Auth,  { headers: this.headers ,observe: 'response'})
      .subscribe(
       (response: HttpResponse<any>) => 
        {
          const keys = response.headers.keys();
          keys.forEach(key => {
            this._localstorageservice.setData(key,response.headers.get(key))
          });
          resolve(response.body);
        },
        (error) => {
          console.error('An error occurred:', error);
          reject(error); 
        }
      );


      
      
    });
  }

}
