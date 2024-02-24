import { CommonModule } from '@angular/common';
import { Component, OnInit, inject} from '@angular/core';
import { AddCarsComponent } from "../add-cars/add-cars.component";
import { CarDetails, GetCarDetails } from '../interface/details';
import { AppService } from '../services/app.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-car-details',
    standalone: true,
    templateUrl: './car-details.component.html',
    styleUrl: './car-details.component.css',
    imports: [CommonModule, AddCarsComponent]
})
export class CarDetailsComponent implements OnInit{
  carDetails !:GetCarDetails;
  imagesrc :string='';
  isAcAvailable : boolean=false;
  CarService = inject(AppService);
  router = inject(Router);

  ngOnInit(): void {
    this.getCars();
  }
  private getCars():void{
     this.CarService.getCars('AS12D3456').subscribe(response => {this.carDetails=response,
      this.imagesrc='data:image/jpeg;base64,'+this.carDetails.imageData,
      this.isAcAvailable=this.carDetails.hasAC});
  }
  // showMore=false;
  // toggleContent(){
  //   this.showMore = !this.showMore;
  // }

addToWishList(car:GetCarDetails){
  //call service to add to wishlist
  this.router.navigate(['/details', car]);
}
bookCar(car:GetCarDetails) {
  this.router.navigate(['/book-car', car]);
}

}

