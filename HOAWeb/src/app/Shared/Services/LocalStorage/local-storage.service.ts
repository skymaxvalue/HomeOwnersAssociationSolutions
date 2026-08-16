import { Injectable } from '@angular/core';
import { OTPModel } from 'src/app/ParkingModels/OTPModel/otpmodel';
import { JsonService } from '../JsonHelper/json.service';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  constructor(private jsonService:JsonService) { }

  




  // Example of saving data to localStorage
setData(key: string, data: any): void 
  {
    this.removeData(key);
    localStorage.setItem(key, this.jsonService.Stringify(data));
  }

  // Example of retrieving data from localStorage
  getData(key: string): any {
    const data = localStorage.getItem(key);
    return data ? this.jsonService.Parse(data) : null;
  }

  // Example of removing data from localStorage
  removeData(key: string): void {
    localStorage.removeItem(key);
  }

}
