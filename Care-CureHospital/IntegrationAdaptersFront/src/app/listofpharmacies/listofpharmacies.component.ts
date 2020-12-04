import { Component, OnInit } from '@angular/core';
import { PharmacyService } from 'src/app/pharmacy.service';

@Component({
    selector: 'app-listofpharmacies',
    templateUrl: './listofpharmacies.component.html',
    styleUrls: ['./listofpharmacies.component.css']
  })

  export class ListofPharmaciesComponent implements OnInit {

    categories = [];
  
    constructor(private pharmacyService: PharmacyService) { }
  
    ngOnInit() {
        this.getAll();
    }
  
    private getAll(): void {
        this.pharmacyService.getAllPharmacies().subscribe(data => {
          this.categories = data;
          console.log("Pharmacies: ",this.categories)
        }, error => {
          console.log('Error');
        });
      }
 
  }