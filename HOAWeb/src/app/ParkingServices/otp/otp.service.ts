import { HttpClient,HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { APIUrlService } from 'src/app/Shared/Services/APIServiceLinks/apiurl.service';
import { LocalStorageService } from 'src/app/Shared/Services/LocalStorage/local-storage.service';
import { HeaderService } from 'src/app/Shared/Services/header/header.service';

@Injectable({
  providedIn: 'root'
})
export class OtpService {

  private headers: HttpHeaders;  
  constructor(private http: HttpClient,private _APIUrlService:APIUrlService,    private headerService:HeaderService,private _localstorageservice:LocalStorageService) 
  {this.headers = this.headerService.getHeaders();}
  
  ValidateOTP(data: any): Promise<any> 
  {
      return new Promise((resolve, reject) => {
      this.http.post<any>(this._APIUrlService.otp, data, { headers: this.headers ,observe: 'response'})
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
