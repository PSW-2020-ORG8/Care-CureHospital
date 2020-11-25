import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DirectorComponent } from './director/director.component'
import { DoctorComponent } from './doctor/doctor.component'


const routes: Routes = [
{path:'director', component:DirectorComponent},
{path:'doctor', component:DoctorComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
