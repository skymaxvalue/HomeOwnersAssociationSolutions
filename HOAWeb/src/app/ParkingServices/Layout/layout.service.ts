import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { APIUrlService } from 'src/app/Shared/Services/APIServiceLinks/apiurl.service';
import { OTPModel } from 'src/app/ParkingModels/OTPModel/otpmodel';
import { HeaderService } from 'src/app/Shared/Services/header/header.service';

@Injectable({
  providedIn: 'root'
})
export class LayoutService {
  private headers: HttpHeaders;
  constructor(private http: HttpClient,private _APIUrlService:APIUrlService,private headerService:HeaderService) 
  {this.headers = this.headerService.getHeaders();}

    

  getUmMenu(username:string): Promise<any> {
    
    return new Promise((resolve, reject) => 
      {

     this.http.get<any>(this._APIUrlService.Layout+"/"+username, { headers: this.headers }).subscribe(
        (response) => {
          resolve(response);
        },
        (error) => {
          console.error('An error occurred:', error);
          reject(error); // Reject the promise with the error to handle it in the component/service where this method is called
        }
      );
    });
  }

  getLoggedInUserDetails(username:string): Promise<any> {
    
    return new Promise((resolve, reject) => 
      {

     this.http.get<any>(this._APIUrlService.LoggedInUserDetails+"/"+username, { headers: this.headers }).subscribe(
        (response) => {
          resolve(response);
        },
        (error) => {
          console.error('An error occurred:', error);
          reject(error); // Reject the promise with the error to handle it in the component/service where this method is called
        }
      );
    });
  }
}
