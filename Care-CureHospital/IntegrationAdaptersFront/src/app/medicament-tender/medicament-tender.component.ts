import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-medicament-tender',
  templateUrl: './medicament-tender.component.html',
  styleUrls: ['./medicament-tender.component.css']
})
export class MedicamentTenderComponent implements OnInit {

  constructor() { }

  ModalTitle:string;
  ActivateAddEditOffer:boolean=false;

  ngOnInit(): void {
  }

  addOffer(){
    this.ModalTitle="Add offer";
    this.ActivateAddEditOffer=true;
  }

  closeClick(){
    this.ActivateAddEditOffer=false;
  }
}
