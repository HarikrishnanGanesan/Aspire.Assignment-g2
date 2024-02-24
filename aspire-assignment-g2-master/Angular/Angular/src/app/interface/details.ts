export interface CarDetails {

  registrationNumber : string;
  manufacturerName : string;
  model : string;
  modelYear : number;
  passengerCapacity : number;
  colour : string;
  transmissionType : string;
  fuelType : string;
  hasAC : boolean;
  mileage : number;
  imageData : any;
  imageFile: File;
  kilometersDriven : number;
  pricePerHour : number;
  pricePerDay : number
  pricePerWeek : number;
  available : string;
  description : string;

}

export interface GetCarDetails {

  registrationNumber : string;
  manufacturerName : string;
  model : string;
  modelYear : number;
  passengerCapacity : number;
  colour : string;
  transmissionType : string;
  fuelType : string;
  hasAC : boolean;
  mileage : number;
  imageData : any;
  kilometersDriven : number;
  pricePerHour : number;
  pricePerDay : number
  pricePerWeek : number;
  available : string;
  description : string;

}
