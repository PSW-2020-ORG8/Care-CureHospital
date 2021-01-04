import { Component, OnInit } from '@angular/core';
import { Offer } from '../models/Offer';

@Component({
  selector: 'app-offer',
  templateUrl: './offer.component.html',
  styleUrls: ['./offer.component.css']
})
export class OfferComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  
  add(){
    alert("You have successfully added your offer!");
  }
}
