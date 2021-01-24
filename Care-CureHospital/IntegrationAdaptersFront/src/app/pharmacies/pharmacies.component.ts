import { Component, OnInit } from '@angular/core';
import { PharmacyService } from 'src/app/pharmacy.service';
import { Pharmacy } from './pharmacy';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-pharmacies',
  templateUrl: './pharmacies.component.html',
  styleUrls: ['./pharmacies.component.css']
})
export class PharmacyComponent implements OnInit {

  pharmacy = new Pharmacy(null,null,null);

  constructor(private pharmacyService : PharmacyService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmitPharmacy(){ 
    console.log(this.pharmacy)
    this.pharmacyService.addPh(this.pharmacy).subscribe(data => {
      console.log('Success!', JSON.stringify(data))
      this.toastr.success("Successfully registrated pharmacy!")
    }, error => {
      console.log('Error');
      this.toastr.success("You didn't manage to register pharmacy!")
    });
  }
}