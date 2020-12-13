import { Component, OnInit } from '@angular/core';
import { DoctorService } from 'src/app/doctor.service';
import { EPrescription } from './models/ePrescription';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.css']
})
export class DoctorComponent implements OnInit {

  constructor(private service:DoctorService) { }

  EPrescriptionList: EPrescription[];

  ModalTitle:string;
  ActivateAddEditEPComp:boolean=false;
  ep:EPrescription;

  ngOnInit(): void {
    this.refreshPrescList();
  }

  addEP(){
    this.ep = {
      id: 0,
      patientId: 0,
      patientName: "",
      comment: "",
      medicamentName:"",
      publishingDate: null
    }
    this.ModalTitle="Add EPrescription";
    this.ActivateAddEditEPComp=true;
  }

  refreshPrescList(){
    this.service.getEPrescriptionList().subscribe((data:EPrescription[])  => {
      console.log(data);
      this.EPrescriptionList = data;
    });
  }

  closeClick(){
    this.ActivateAddEditEPComp=false;
  }

  generateEP(){
    alert("EPrescription Saved!");
  }
}
