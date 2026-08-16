import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { LocalStorageService } from '../LocalStorage/local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class HeaderService {

  constructor(private _localStorageService:LocalStorageService) { }


  private headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization':  this._localStorageService.getData('authorization')??'test'
  });

  getHeaders(): HttpHeaders {
    // this.setAuthorizationHeader();
    return this.headers;
  }
}