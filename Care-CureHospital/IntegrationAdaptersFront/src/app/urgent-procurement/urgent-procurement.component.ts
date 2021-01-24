import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Input } from '@angular/core';
import { PharmacyService } from 'src/app/pharmacy.service';
import { MedicamentUrgentOrder } from '../models/MedicamentUrgentOrder';
import { Pharmacy } from '../pharmacies/pharmacy';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-urgent-procurement',
  templateUrl: './urgent-procurement.component.html',
  styleUrls: ['./urgent-procurement.component.css']
})
export class UrgentProcurementComponent implements OnInit {

  constructor(private service: PharmacyService, public http: HttpClient, private toastr: ToastrService) { }

  @Input() med:MedicamentUrgentOrder;
  name: string;
  quantity: number;

  pharmacy: Pharmacy;
  MedList:any=[];

  ngOnInit(): void {
  }

  sendRequest(){
    var val = {
      id: this.MedList.id,
      name: this.MedList.name,
      quantity: this.MedList.quantity
    };
    console.log(this.MedList);

    try{
        this.service.sendReqWithHttp(val).subscribe(res =>{
          console.log(JSON.stringify(res));
        });
    } finally{
        this.service.sendSftpReq(val).subscribe(res => {
          console.log(JSON.stringify(res));
          this.toastr.success("Successfully sent!")
        })
      }
  }
}