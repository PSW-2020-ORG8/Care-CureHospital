import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Input } from '@angular/core';
import { PharmacyService } from 'src/app/pharmacy.service';
import { MedicamentUrgentOrder } from '../models/MedicamentUrgentOrder';

@Component({
  selector: 'app-urgent-procurement',
  templateUrl: './urgent-procurement.component.html',
  styleUrls: ['./urgent-procurement.component.css']
})
export class UrgentProcurementComponent implements OnInit {

  constructor(private service: PharmacyService, public http: HttpClient) { }

  @Input() med:MedicamentUrgentOrder;
  name: string;
  quantity: number;

  MedList:any=[];

  ngOnInit(): void {
  }

  sendHttpRequest(){
    var val = {
      id: this.MedList.id,
      name: this.MedList.name,
      quantity: this.MedList.quantity
    };
    console.log(this.MedList);
    this.service.sendReqWithHttp(val).subscribe(res =>{
      console.log(JSON.stringify(res));
    });
  }
}
