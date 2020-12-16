import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pharmacy } from './pharmacies/pharmacy';



@Injectable({
    providedIn: 'root'
  })

  export class PharmacyService {
    constructor(private http: HttpClient) { 
    }

    addPh(pharmacy: Pharmacy): Observable<any> {
        return this.http.post(`http://localhost:51492/api/pharmacy/addPharmacy`, pharmacy);
      }

    getAllPharmacies(): Observable<any> {
        return this.http.get(`http://localhost:51492/api/pharmacy/getPharmacies`);
      }
  }