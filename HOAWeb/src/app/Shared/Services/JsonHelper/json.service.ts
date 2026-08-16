import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class JsonService {

  constructor() { }

  
  public Stringify(data:any):any{
    return JSON.stringify(data);
  }

  
  public Parse(response:any):any{
    return JSON.parse(response);
  }
}
