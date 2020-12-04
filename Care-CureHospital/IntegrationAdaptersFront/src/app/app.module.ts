import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DirectorComponent } from './director/director.component';
import { DoctorComponent } from './doctor/doctor.component';
import { ReportComponent } from './director/report/report.component';
import { DirectorServiceService } from './director-service.service';
import { ListofPharmaciesComponent } from './listofpharmacies/listofpharmacies.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import{ HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddReportComponent } from './director/add-report/add-report.component';
import { MatTableExporterModule } from 'mat-table-exporter';
import { MatButtonModule } from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [
    AppComponent,
    DirectorComponent,
    DoctorComponent,
    ReportComponent,
    AddReportComponent,
    ListofPharmaciesComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule, 
    ReactiveFormsModule,
    MatTableExporterModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatToolbarModule,
    CommonModule,
    BrowserAnimationsModule,
    MatIconModule,
  ],
  providers: [ DirectorServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
