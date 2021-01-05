import { Component, OnInit } from '@angular/core';
import { TenderServiceService } from 'src/app/tender-service.service';
import { Tender } from '../models/Tender';

@Component({
  selector: 'app-medicament-tender',
  templateUrl: './medicament-tender.component.html',
  styleUrls: ['./medicament-tender.component.css']
})
export class MedicamentTenderComponent implements OnInit {

  constructor(private tenderService:TenderServiceService) { }

  medicamentName:string;
  startDate:Date;
  endDate:Date;

  TenderList: Tender[];

  ModalTitle:string;
  ActivateAddEditOffer:boolean=false;

  ngOnInit(): void {
    this.refreshTenderList();
  }

  addOffer(){
    this.ModalTitle="Add offer";
    this.ActivateAddEditOffer=true;
  }

  closeClick(){
    this.ActivateAddEditOffer=false;
  }

  refreshTenderList(){
    this.tenderService.getActiveTender().subscribe((data: Tender[]) => {
      console.log(data);
      this.TenderList = data;
    })
  }
}
