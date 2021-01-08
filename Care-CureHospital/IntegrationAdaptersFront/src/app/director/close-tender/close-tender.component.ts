import { Component, OnInit } from '@angular/core';
import { Tender } from 'src/app/models/Tender';
import { TenderServiceService } from 'src/app/tender-service.service';

@Component({
  selector: 'app-close-tender',
  templateUrl: './close-tender.component.html',
  styleUrls: ['./close-tender.component.css']
})
export class CloseTenderComponent implements OnInit {

  constructor(private tenderService:TenderServiceService) { }
  
  id:number;
  medicamentName : string;
  startDate : Date;
  endDate : Date;

  TenderList:Tender[];

  ngOnInit(): void {
    this.reresh();
  }

  
  closeTender(){
    this.tenderService.closeTender(this.id).subscribe(data =>{
       console.log(data);
     })
     alert("Successfully closed!");
   }

   reresh(){
    this.tenderService.getActiveTender().subscribe((data: Tender[]) => {
      console.log(data);
      this.TenderList = data;
    })
   }

}
