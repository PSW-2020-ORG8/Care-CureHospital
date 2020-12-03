import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DirectorComponent } from './director/director.component';
import { DoctorComponent } from './doctor/doctor.component';
import { ReportComponent } from './director/report/report.component';
import { DirectorServiceService } from './director-service.service';

import{ HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddReportComponent } from './director/add-report/add-report.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    DirectorComponent,
    DoctorComponent,
    ReportComponent,
    AddReportComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule, 
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [DirectorServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
