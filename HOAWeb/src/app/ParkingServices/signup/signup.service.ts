import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { APIUrlService } from 'src/app/Shared/Services/APIServiceLinks/apiurl.service';
import { HeaderService } from 'src/app/Shared/Services/header/header.service';

@Injectable({
  providedIn: 'root'
})
export class SignupService {

  private headers: HttpHeaders;
  constructor(private http: HttpClient,private _APIUrlService:APIUrlService,private headerService:HeaderService) 
  {this.headers = this.headerService.getHeaders();}
  
  GetBannerUpdates(): Promise<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'accept':'text/plain',
      'Authorization': 'Bearer your_access_token' // Replace 'your_access_token' with your actual access token
    });

    return new Promise((resolve, reject) => {
      this.http.get<any>(this._APIUrlService.SignupUrl, { headers }).subscribe(
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


  SignUp(data: any): Promise<any> {


    return new Promise((resolve, reject) => {
      this.http.post<any>(this._APIUrlService.SignupUrl, data, { headers: this.headers }).subscribe(
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

  LoadHOAMaster(): Promise<any> {
   
    return new Promise((resolve, reject) => {
      this.http.get<any>(this._APIUrlService.LoadHOAMaster, {  headers: this.headers }).subscribe(
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
