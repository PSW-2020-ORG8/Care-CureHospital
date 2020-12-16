import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {
  readonly APIUrl = "http://localhost:51492/api";

  constructor(private http:HttpClient) {
    this.getEPrescriptionList();
   }

  getEPrescriptionList():Observable<any>{
    return this.http.get(this.APIUrl+'/eprescription');
  }

  addEPrescription(val:any){
    return this.http.post(this.APIUrl+'/eprescription', val);
  }

  updateEPrescription(val:any){
    return this.http.put(this.APIUrl+'/eprescription', val);
  }

  generateEP(val:any){
    return this.http.get<any[]>(this.APIUrl+'/sftpep');
  }
}
