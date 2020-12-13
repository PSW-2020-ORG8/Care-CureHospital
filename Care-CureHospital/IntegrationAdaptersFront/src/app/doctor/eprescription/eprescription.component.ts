import { Component, OnInit, Input } from '@angular/core';
import { DoctorService } from 'src/app/doctor.service';
import { EPrescription } from '../models/ePrescription';

@Component({
  selector: 'app-eprescription',
  templateUrl: './eprescription.component.html',
  styleUrls: ['./eprescription.component.css']
})
export class EprescriptionComponent implements OnInit {

  constructor(private service:DoctorService) { }

  @Input() ep:EPrescription;


  Id : number;
  PatientId : number;
  PatientName : string;
  Comment : string;
  MedicamentName : string;
  PublishingDate : Date;
 // MedicationName:string;

  EPrescriptionList:any=[];
  
  


  ngOnInit(): void {
    this.Id=this.ep.id;
    this.PatientId=this.ep.patientId;
    this.PatientName=this.ep.patientName;
    this.Comment=this.ep.comment;
    this.MedicamentName=this.ep.medicamentName;
    this.PublishingDate=this.ep.publishingDate;
  }


  addEPrescription(){
    var val = { Id:this.Id,
                PatientId:this.PatientId,
                PatientName:this.PatientName,
                Comment:this.Comment,
                MedicamentName:this.MedicamentName,
                PublishingDate:this.PublishingDate
                };
    this.service.addEPrescription(val).subscribe(
      epr => {alert(epr.toString())});
  alert("Successfully added medication!");
  }
}
