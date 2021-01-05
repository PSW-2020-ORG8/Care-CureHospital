import { Component, OnInit } from '@angular/core';
import { Offer } from '../../models/Offer';
import { TenderServiceService } from 'src/app/tender-service.service';

@Component({
  selector: 'app-inactive-tender',
  templateUrl: './inactive-tender.component.html',
  styleUrls: ['./inactive-tender.component.css']
})
export class InactiveTenderComponent implements OnInit {

  constructor(private tenderService:TenderServiceService) { }

  medicamentId:number;
  price:number;
  quantity:number;
  comment:string;

  OfferList: Offer[];

  ngOnInit(): void {
    this.refreshOfferInactiveList();
  }

  refreshOfferInactiveList(){
    this.tenderService.getOfferListInactive().subscribe((data: Offer[]) => {
      console.log(data);
      this.OfferList = data;
    })
  }

}
