import { Observable, throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pharmacy } from './pharmacies/pharmacy';
import { map, catchError } from 'rxjs/operators';
import { MedicamentUrgentOrder } from './models/MedicamentUrgentOrder';

@Injectable({
    providedIn: 'root'
  })

  export class PharmacyService {
    readonly APIUrl = "http://localhost:61793/gateway";

    constructor(private http: HttpClient) { 
      this.generateMedicamentStock();
    }

    addPh(pharmacy: Pharmacy): Observable<any> {
      return this.http.post(`http://localhost:61793/gateway/pharmacy/addPharmacy`, pharmacy).
      pipe(
        map((data: any) => {
          return data;
        }), catchError( error => {
          return throwError( 'Server is not responding!' );
        })
      )
    }

    getAllPharmacies(): Observable<any> {
      return this.http.get(`http://localhost:61793/gateway/pharmacy/getPharmacies`).
      pipe(
        map((data: any) => {
          return data;
        }), catchError( error => {
          return throwError( 'Server is not responding!' );
        })
      )
    }  

    generateMedicamentStock():Observable<any>{
      return this.http.get<any>(this.APIUrl+'/stock');
    }

    sendReqWithHttp(val:MedicamentUrgentOrder):Observable<MedicamentUrgentOrder>{
      return this.http.post<MedicamentUrgentOrder>(this.APIUrl+'/urgentorder', val).
      pipe(
        map((data: any) => {
          return data;
        }), catchError( error => {
          return throwError( 'Your order is not sent! Server is not responding!' );
        })
      )
    }
  }