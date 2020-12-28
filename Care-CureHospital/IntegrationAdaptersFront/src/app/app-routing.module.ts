import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DirectorComponent } from './director/director.component'
import { DoctorComponent } from './doctor/doctor.component'
import { ListofPharmaciesComponent } from './listofpharmacies/listofpharmacies.component'
import { PharmacyComponent } from './pharmacies/pharmacies.component'
import { UrgentProcurementComponent } from './urgent-procurement/urgent-procurement.component';

const routes: Routes = [
{path:'director', component:DirectorComponent},
{path:'doctor', component:DoctorComponent},
{path:'pharmacy', component:PharmacyComponent},
{path:'listofpharmacies', component:ListofPharmaciesComponent},
{path:'urgentProcurement', component:UrgentProcurementComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
