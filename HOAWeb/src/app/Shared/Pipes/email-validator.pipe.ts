import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'emailValidator'
})
export class EmailValidatorPipe implements PipeTransform {

  transform(value: string): boolean 
  {
    const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    return emailRegex.test(value);
  }



}
