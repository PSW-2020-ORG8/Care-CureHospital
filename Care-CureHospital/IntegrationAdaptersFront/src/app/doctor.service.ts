import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { EPrescription } from './models/EPrescription';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {
 readonly APIUrl = "http://localhost:61793/gateway";

  constructor(private http:HttpClient) {
    this.getEPrescriptionList();
   }

  getEPrescriptionList():Observable<any>{
    return this.http.get(this.APIUrl+'/eprescription').
    pipe(
      map((data: any) => {
        return data;
      }), catchError( error => {
        return throwError( 'Server is not responding!' );
      })
    )
  }

  addEPrescription(val:EPrescription):Observable<any>{
    return this.http.post(this.APIUrl+'/eprescription', val).
    pipe(
      map((data: any) => {
        return data;
      }), catchError( error => {
        return throwError( 'Server is not responding!' );
      })
    )
  }

  updateEPrescription(val:any){
    return this.http.put(this.APIUrl+'/eprescription', val);
  }

  generateEP(val:EPrescription):Observable<EPrescription>{
    return this.http.post<EPrescription>(this.APIUrl+'/eprescription/send', val).
    pipe(
      map((data: any) => {
        return data;
      }), catchError( error => {
       // window.alert(error);
        return throwError( 'You can not sent prescription because server is not responding!' );
      })
    )
  }
}
