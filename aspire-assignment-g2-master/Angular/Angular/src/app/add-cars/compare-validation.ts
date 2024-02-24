import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export const compareValidator : ValidatorFn = (control: AbstractControl): ValidationErrors | null => {
  const dayprice = control.get('pricePerDay');
  const hourprice = control.get('pricePerHour');
  const weekprice = control.get('pricePerWeek');
  if(dayprice?.value < hourprice?.value && weekprice?.value < dayprice?.value)
  {
    return {'wrongPrice' : true}
  }
return null;
};
