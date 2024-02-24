import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { App } from '../interface/app';
import { CarDetails, GetCarDetails } from '../interface/details';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  public selectedApp: App = {} as App;
  apiBaseAddress = environment.apiBaseAddress;
  constructor(private http: HttpClient) { }

  getApp() {
    return this.http.get<App[]>(this.apiBaseAddress + 'api/App');
  }
    getCars(regNo:string):Observable<GetCarDetails> {
    return this.http.get<GetCarDetails>(this.apiBaseAddress + 'api/Cars/GetCarDetails/'+regNo);
  }
  addCar( data:FormData):any{
    return this.http.post(this.apiBaseAddress+'api/Cars/AddCar',data);
  }
}
