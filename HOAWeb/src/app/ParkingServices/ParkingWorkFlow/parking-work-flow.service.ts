import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { APIUrlService } from 'src/app/Shared/Services/APIServiceLinks/apiurl.service';
import { HeaderService } from 'src/app/Shared/Services/header/header.service';

@Injectable({
  providedIn: 'root'
})
export class ParkingWorkFlowService {

  private headers: HttpHeaders;
  constructor(private http: HttpClient,private _APIUrlService:APIUrlService,private headerService:HeaderService) 
  {this.headers = this.headerService.getHeaders();}


  
  ParkingRequestWorkFlowUpdate(data: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.post<any>(this._APIUrlService.ParkingWorkFlowUpdate, data, { headers: this.headers }).subscribe(
        (response) => {
          resolve(response);
        },
        (error) => {
          console.error('An error occurred:', error);
          reject(error);         }
      );
    });
  }

  GetAllParkingRequest(userName: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.get<any>(this._APIUrlService.GetAllParkingRequest+"/"+userName, { headers: this.headers }).subscribe(
        (response) => {
          resolve(response);
        },
        (error) => {
          console.error('An error occurred:', error);
          reject(error);         }
      );
    });
  }

  GetAllTowingCompanyAssignments(userName: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.get<any>(this._APIUrlService.GetAllTowingCompanyAssignments+"/"+userName, { headers: this.headers }).subscribe(
        (response) => {
          resolve(response);
        },
        (error) => {
          console.error('An error occurred:', error);
          reject(error);         }
      );
    });
  }

  GetAllHOAAssignments(userName: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.get<any>(this._APIUrlService.GetAllHOAAssignments+"/"+userName, { headers: this.headers }).subscribe(
        (response) => {
          resolve(response);
        },
        (error) => {
          console.error('An error occurred:', error);
          reject(error);         }
      );
    });
  }
    
  GetParkingRequest(ParkingRequestId: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.get<any>(this._APIUrlService.GetParkingRequest+"/"+ParkingRequestId,{ headers: this.headers }).subscribe(
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
