import { NgModule } from '@angular/core';
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';
import { ActiveTenderComponent } from './director/active-tender/active-tender.component';
import { DirectorComponent } from './director/director.component'
import { InactiveTenderComponent } from './director/inactive-tender/inactive-tender.component';
import { ShowOfferComponent } from './director/show-offer/show-offer.component';
import { DoctorComponent } from './doctor/doctor.component'
import { TenderComponent } from './doctor/tender/tender.component';
import { ListofPharmaciesComponent } from './listofpharmacies/listofpharmacies.component'
import { MedicamentTenderComponent } from './medicament-tender/medicament-tender.component';
import { PharmacyComponent } from './pharmacies/pharmacies.component'
import { UrgentProcurementComponent } from './urgent-procurement/urgent-procurement.component';

const routes: Routes = [
{path:'director', component:DirectorComponent},
{path:'doctor', component:DoctorComponent},
{path:'pharmacy', component:PharmacyComponent},
{path:'listofpharmacies', component:ListofPharmaciesComponent},
{path:'urgentProcurement', component:UrgentProcurementComponent},
{path: 'tender', component:TenderComponent},
{path: 'medicamentTender', component:MedicamentTenderComponent},
{path: 'showOffers', component:ShowOfferComponent},
{path: 'activeTender', component:ActiveTenderComponent},
{path: 'inactiveTender', component:InactiveTenderComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
