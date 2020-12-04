import { Component, OnInit } from '@angular/core';
import { Pharmacy } from 'src/app/doctor/pharmacy';
import { PharmacyService } from 'src/app/pharmacy.service';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.css']
})
export class DoctorComponent implements OnInit {

  pharmacy = new Pharmacy(null,null,null);

  constructor(private pharmacyService : PharmacyService) { }

  ngOnInit(): void {
  }

  onSubmitPharmacy(){ 
    console.log(this.pharmacy)
    this.pharmacyService.addPh(this.pharmacy).subscribe(data => {
      console.log('Success!', JSON.stringify(data))
      alert('Uspesna registracija apoteke!')
    }, error => {
      console.log('Error');
      alert('Niste uspesno registrovali apoteku')
    });
  }
}
