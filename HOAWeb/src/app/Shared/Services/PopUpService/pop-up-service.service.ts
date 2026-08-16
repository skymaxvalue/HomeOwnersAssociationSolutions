import { Injectable } from '@angular/core';
import Swal from 'sweetalert2'

@Injectable({
  providedIn: 'root'
})
export class PopUpServiceService {

  constructor() { }

  Alert(message:string)
  {
    Swal.fire("PopUp Working");
  }
  Success(Title:string,message:string)
  {
    Swal.fire(Title,message,'success');
  }
  Error(Title:string,message:string)
  {
    Swal.fire(Title,message,"error");
  }
  Info(Title:string,message:string)
  {
    Swal.fire(Title,message,"info");
  }
  Warning(Title:string,message:string)
  {
    Swal.fire(Title,message,"warning");
  }
  ConfirmQuestion(title:string,
    message:string,
    confirmBtnText:string,
    cancelBtnText:string,
    onConfirmTitle:string,
    onConfirmText:string)
  {
    Swal.fire({
      title:title,
      text:message,
      icon:'question',
      showCancelButton:true,
      confirmButtonText:confirmBtnText,
      cancelButtonText:cancelBtnText
      }).then((result)=>
      
      {
        if(result.value){
          Swal.fire(onConfirmTitle,onConfirmText,'success')
        }
      });
  }
  ConfirmWarning(title:string,
    message:string,
    confirmBtnText:string,
    cancelBtnText:string,
    onConfirmTitle:string,
    onConfirmText:string)
  {
    Swal.fire({
      title:title,
      text:message,
      icon:'warning',
      showCancelButton:true,
      confirmButtonText:confirmBtnText,
      cancelButtonText:cancelBtnText
      }).then((result)=>
      
      {
        if(result.value){
          Swal.fire(onConfirmTitle,onConfirmText,'success')
        }
      });
  }
 
  HtmlErrorPopup( 
    htmlinput:string,
    title:string,)
  {
    Swal.fire({
      title:title,
      html:htmlinput,
      text:title,
      icon:'error',
      confirmButtonText: "Ok", 
      allowOutsideClick:true
      });
  }
  HtmlSuccessPopup( 
    htmlinput:string,
    title:string,
  )
  {
    Swal.fire({
      title:title,
      html:htmlinput,
      text:title,
      icon:'success',
      confirmButtonText: "Ok", 
      allowOutsideClick:true
      });
  }

}
