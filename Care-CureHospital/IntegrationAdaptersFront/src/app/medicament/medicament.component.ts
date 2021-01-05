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
   quantity:number;

   httpResponse: String="";

    MedicamentList:Medicament[]=[
      {
        id:1,
        name: "Aspirin",
        quantity: 40
      },
      {
        id:2,
        name: "Bromazepan",
        quantity: 20
      },
      {
        id:2,
        name: "Vitamin B",
        quantity: 60
      }
    ];

  ngOnInit(): void {
   /* this.med={
      id: 0,
      name:"",
      quantity: 0
    };*/
  }

  sendRequest(){
    this.service.generateMedicamentStock().subscribe((data:Medicament[]) =>{
      this.MedicamentList = data;
      console.log(this.MedicamentList);
      alert(data);
    }, error => {
      console.log('Error');
    });
  }
}
