import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { APIUrlService } from 'src/app/Shared/Services/APIServiceLinks/apiurl.service';
import { HeaderService } from 'src/app/Shared/Services/header/header.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private headers: HttpHeaders;
  constructor(private http: HttpClient,private _APIUrlService:APIUrlService,private headerService:HeaderService) 
  {this.headers = this.headerService.getHeaders();}


  Login(data: any): Promise<any> {
  
    return new Promise((resolve, reject) => {
      this.http.post<any>(this._APIUrlService.login, data, {headers: this.headers }).subscribe(
        (response) => {
          resolve(response);
        },
        (error) => {
          console.error('An error occurred:', error);
          reject(error); 
        }
      );
    });
  }


}
