import { Component, Input, OnInit } from '@angular/core';
import { DirectorServiceService } from '../director-service.service';
import { DoctorService } from '../doctor.service';
import { Offer } from '../models/Offer';

@Component({
  selector: 'app-offer',
  templateUrl: './offer.component.html',
  styleUrls: ['./offer.component.css']
})
export class OfferComponent implements OnInit {

  constructor(private service:DirectorServiceService) { }

  @Input() off:Offer;
  price:number;
  quantity:number;
  commnet:string;

  OfferList:any=[];

  ngOnInit(): void {
    this.price = this.off.price;
    this.quantity = this.off.quantity;
    this.commnet = this.off.comment;
  }
  
  addOffer(){
    var val = {
      price:this.OfferList.price,
      quantity:this.OfferList.quantity,
      comment:this.OfferList.commnet
    };

    this.service.addOffers(val).subscribe(res => {
      alert(res.toString())});
    alert("You have successfully added your offer!");
  }
}
