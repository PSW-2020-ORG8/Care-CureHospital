import { Component, OnInit } from '@angular/core';
import { PharmacyService } from 'src/app/pharmacy.service';

@Component({
  selector: 'app-urgent-procurement',
  templateUrl: './urgent-procurement.component.html',
  styleUrls: ['./urgent-procurement.component.css']
})
export class UrgentProcurementComponent implements OnInit {

  constructor(private service: PharmacyService) { }

  httpResponse: String="";

  ngOnInit(): void {
  }

  sendHttpRequest(){
    this.service.sendReqWithHttp().subscribe(res =>{
      this.httpResponse = res;
      alert(res);
      console.log(res);
    });
  }
}
