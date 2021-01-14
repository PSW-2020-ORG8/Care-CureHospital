import { Component, OnInit, Input } from '@angular/core';
import { Tender } from 'src/app/models/Tender';
import { TenderServiceService } from 'src/app/tender-service.service';
import { HttpClient } from '@angular/common/http'; 

@Component({
  selector: 'app-close-tender',
  templateUrl: './close-tender.component.html',
  styleUrls: ['./close-tender.component.css']
})
export class CloseTenderComponent implements OnInit {

  constructor(private tenderService:TenderServiceService, public http: HttpClient) { }
  
  tender:Tender;
  id:number;
  medicamentName : string;
  startDate : Date;
  endDate : Date;
  active: boolean;

  ActivateAddEditRepComp:boolean=false;

  TenderList: Tender[];

  ngOnInit(): void {
    this.reresh();
  }
  
  closeTender(id:number){
    console.log(id);
    this.tenderService.closeTender(id).subscribe(data =>{
       console.log(data);
     })
   }

   reresh(){
    this.tenderService.getActiveTender().subscribe((data: Tender[]) => {
      console.log(data);
      this.TenderList = data;
    })
  }
}
