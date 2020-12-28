import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Input } from '@angular/core';
import { Medicament } from '../models/Medicament';
import { PharmacyService } from '../pharmacy.service';

@Component({
  selector: 'app-medicament',
  templateUrl: './medicament.component.html',
  styleUrls: ['./medicament.component.css']
})
export class MedicamentComponent implements OnInit {

  constructor(private httpClient : HttpClient, private service:PharmacyService) { }

  @Input() med:Medicament;
   name:string;
   quantity:string;

  medList:any=[];

  ngOnInit(): void {
    this.sendRequest();
  }

  sendRequest(){
    alert("Request sent!");
  }
}
