import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HtmlHelperService {

  constructor() { }

  IsBusinessValidationError(errorResponse:string): string
  {
   
      
     ;
      var returnmsg='';
     
        returnmsg = '<ul>';
        errorResponse.split(';').forEach((res)=>
          {
          
            returnmsg += `<li>${res}</li>`;

          });
          returnmsg += '</ul>';

      
      return returnmsg
   
  }

}
