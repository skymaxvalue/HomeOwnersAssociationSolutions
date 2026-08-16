import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { APIUrlService } from 'src/app/Shared/Services/APIServiceLinks/apiurl.service';
import { HeaderService } from 'src/app/Shared/Services/header/header.service';

@Injectable({
  providedIn: 'root'
})
export class CustomerProfileService {


  private headers: HttpHeaders;
  constructor(private http: HttpClient,private _APIUrlService:APIUrlService,private headerService:HeaderService) 
  {this.headers = this.headerService.getHeaders();}


  
  ProfileUpdate(data: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.post<any>(this._APIUrlService.MyProfileUpdate, data, { headers: this.headers }).subscribe(
        (response) => {
          resolve(response);
        },
        (error) => {
          console.error('An error occurred:', error);
          reject(error);         }
      );
    });
  }

  HouseOwnerAssociationDetailsUpdate(data: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.post<any>(this._APIUrlService.MyProfileHouseOwnerAssociationDetailsUpdate, data, { headers: this.headers }).subscribe(
        (response) => {
          resolve(response);
        },
        (error) => {
          console.error('An error occurred:', error);
          reject(error);         }
      );
    });
  }

  HouseOwnerDetailsUpdate(data: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.post<any>("", data, { headers: this.headers }).subscribe(
        (response) => {
          resolve(response);
        },
        (error) => {
          console.error('An error occurred:', error);
          reject(error);         }
      );
    });
  }

  TowingCompanyDetailsUpdate(data: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.post<any>(this._APIUrlService.MyProfileTowingCompanyDetailsUpdate, data, { headers: this.headers }).subscribe(
        (response) => {
          resolve(response);
        },
        (error) => {
          console.error('An error occurred:', error);
          reject(error);         }
      );
    });
  }

  GetUserProfileDetails(userid: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.get<any>(this._APIUrlService.MyProfileGetUserProfileDetails+"/"+userid, { headers: this.headers }).subscribe(
        (response) => {
          resolve(response);
        },
        (error) => {
          console.error('An error occurred:', error);
          reject(error);         }
      );
    });
  }

}
