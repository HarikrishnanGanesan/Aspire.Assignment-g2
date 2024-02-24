
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  NgForm,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { compareValidator } from './compare-validation';
import { AppService } from '../services/app.service';
import { CarDetails } from '../interface/details';


@Component({
  selector: 'app-add-cars',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './add-cars.component.html',
  styleUrl: './add-cars.component.css',
})
export class AddCarsComponent {
  list ! : CarDetails[];
  years: number[]=[2005,2006,2007,
    2008,2009,2010,2011,2012,
    2013,2014,2015,2016,2017,2018,
    2019,2020,2021,2022,2023,2024];
    constructor(private service : AppService){
      this.service;
    }
     file ! : File;
    errorMessage : boolean=false;

  addCarForm : FormGroup= new FormGroup(
    {
      registrationNumber: new FormControl<string>('', [
        Validators.required,
        Validators.pattern('^[A-Z]{2}[0-9]{2}[A-Z]{1}[0-9]{1,4}$'),
      ]),
      manufacturerName: new FormControl<string>('', [Validators.required]),
      model: new FormControl<string>('', [Validators.required]),
      modelYear: new FormControl<number>(0, [
        Validators.required,
        Validators.min(2004),
        Validators.max(2024),
      ]),
      passengerCapacity: new FormControl<number>(0, [
        Validators.required,
        Validators.min(3),
      ]),
      colour: new FormControl<string>('', [Validators.required]),
      transmissionType: new FormControl<string>('', [Validators.required]),
      fuelType: new FormControl<string>('', [Validators.required]),
      hasAC: new FormControl<boolean>(false, [Validators.required]),
      mileage: new FormControl<number>(0, [
        Validators.required,
        Validators.min(1),
      ]),
      imageFile: new FormControl(null, [Validators.required]),
      kilometersDriven: new FormControl<number>(0, [
        Validators.required,
        Validators.min(10),
      ]),
      pricePerHour: new FormControl<number>(0, [
        Validators.required,
        Validators.min(100),
      ]),
      pricePerDay: new FormControl<number>(0, [
        Validators.required,
        Validators.min(100),
      ]),
      pricePerWeek: new FormControl<number>(0, [
        Validators.required,
        Validators.min(100),
      ]),
      available: new FormControl<string>('', [Validators.required]),
      description: new FormControl<string>('', [Validators.required]),
      ImageData : new FormControl(null)
    },
    { validators: compareValidator }
  );
  isDisabled(){
    console.log('Form validity:', this.addCarForm.valid);
   return !this.addCarForm.valid;
  }
  onImageUpload(event : any) {
     this.file = event.target.files[0];
    console.log(this.file);
  }
  onMouseOn(){
   this.errorMessage=true;
  }

  onSubmit(){
    const formData=new FormData();
    formData.append('imageFile',this.file);
    formData.append('registrationNumber', this.addCarForm.value.registrationNumber);
    formData.append('manufacturerName', this.addCarForm.value.manufacturerName);
    formData.append('imageData', this.addCarForm.value.imageData);
    formData.append('model', this.addCarForm.value.model);
    formData.append('modelYear', this.addCarForm.value.modelYear);
    formData.append('passengerCapacity', this.addCarForm.value.passengerCapacity);
    formData.append('colour', this.addCarForm.value.colour);
    formData.append('transmissionType', this.addCarForm.value.transmissionType);
    formData.append('fuelType', this.addCarForm.value.fuelType);
    formData.append('hasAC', this.addCarForm.value.hasAC);
    formData.append('mileage', this.addCarForm.value.mileage);
    formData.append('kilometersDriven', this.addCarForm.value.kilometersDriven);
    formData.append('pricePerHour', this.addCarForm.value.pricePerHour);
    formData.append('pricePerDay', this.addCarForm.value.pricePerDay);
    formData.append('pricePerWeek', this.addCarForm.value.pricePerWeek);
    formData.append('available', this.addCarForm.value.available);
    formData.append('description', this.addCarForm.value.description);
    console.log(formData);
    this.service.addCar(formData).subscribe((response : CarDetails[]) =>this.list=response);
   // alert("Success");
  }
}
