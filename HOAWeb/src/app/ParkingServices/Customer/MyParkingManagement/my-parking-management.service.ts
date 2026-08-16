import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { APIUrlService } from 'src/app/Shared/Services/APIServiceLinks/apiurl.service';
import { HeaderService } from 'src/app/Shared/Services/header/header.service';

@Injectable({
  providedIn: 'root'
})
export class MyParkingManagementService {



  
  private headers: HttpHeaders;
  constructor(private http: HttpClient,private _APIUrlService:APIUrlService,private headerService:HeaderService) 
  {this.headers = this.headerService.getHeaders();}


  MyProfileHouseOwnerVechileDetailsSave(data: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.post<any>(this._APIUrlService.MyProfileHouseOwnerVechileDetailsSave, data, { headers: this.headers }).subscribe(
        (response) => {
          resolve(response);
        },
        (error) => {
          console.error('An error occurred:', error);
          reject(error);         }
      );
    });
  }

  GetAllMyProfileHouseOwnerVechileDetails(UserName: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.get<any>(this._APIUrlService.GetAllMyProfileHouseOwnerVechileDetails+"/"+UserName, { headers: this.headers }).subscribe(
        (response) => {
          resolve(response);
        },
        (error) => {
          console.error('An error occurred:', error);
          reject(error);         }
      );
    });
  }
  GetMyProfileHouseOwnerVechileDetails(id: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.get<any>(this._APIUrlService.GetMyProfileHouseOwnerVechileDetails+"/"+id, { headers: this.headers }).subscribe(
        (response) => {
          resolve(response);
        },
        (error) => {
          console.error('An error occurred:', error);
          reject(error);         }
      );
    });
  }

  DeleteVechileDetails(id: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.get<any>(this._APIUrlService.MyProfileHouseOwnerDeleteVechileDetails+"/"+id, { headers: this.headers }).subscribe(
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
