import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login/login.component';
import { CarDetailsComponent } from './car-details/car-details.component';
import { AddCarsComponent } from './add-cars/add-cars.component';

const routes: Routes = [
  {
    path: '', component: LoginComponent
  },
  {
    path: 'app',
    loadChildren: () => import('./application/application.module').then(m => m.ApplicationModule)
  },
{
  path : 'CarDetails',
  component : CarDetailsComponent
},
{
  path : 'AddCar',
  component : AddCarsComponent
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
