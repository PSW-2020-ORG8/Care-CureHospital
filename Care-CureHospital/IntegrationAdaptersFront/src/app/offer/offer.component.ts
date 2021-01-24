import { Component, Input, OnInit } from '@angular/core';
import { DirectorServiceService } from '../director-service.service';
import { ToastrService } from 'ngx-toastr';
import { HttpClient } from '@angular/common/http'; 
import { Offer } from '../models/Offer';

@Component({
  selector: 'app-offer',
  templateUrl: './offer.component.html',
  styleUrls: ['./offer.component.css']
})
export class OfferComponent implements OnInit {

  constructor(private service:DirectorServiceService, public http: HttpClient, private toastr: ToastrService) { }

  @Input() off:Offer;
  
  id:number;
  pharmacyName:string;
  pharmacyEmail:string;
  price:number;
  quantity:number;
  commnet:string;

  OfferList:any=[];

  ngOnInit(): void {
    this.id = this.off.id;
    this.pharmacyName = this.off.pharmacyName;
    this.pharmacyEmail = this.off.pharmacyEmail;
    this.price = this.off.price;
    this.quantity = this.off.quantity;
    this.commnet = this.off.comment;
  }
  
  addOffer(){
    var val = {
      id:this.OfferList.id,
      pharmacyName:this.OfferList.pharmacyName,
      pharmacyEmail:this.OfferList.pharmacyEmail,
      price:this.OfferList.price,
      quantity:this.OfferList.quantity,
      comment:this.OfferList.comment
    };

    console.log(this.OfferList);
    this.service.addOffers(val).subscribe(res => {
      console.log(res.toString())
   });
    this.toastr.success("Successfully added!")
    }
    
}
