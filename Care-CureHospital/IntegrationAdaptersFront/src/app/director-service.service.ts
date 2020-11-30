import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})

export class DirectorServiceService {
  readonly APIUrl = "http://localhost:51492/api";

  constructor(private http:HttpClient) { }

  getReportList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/report');
  }

  addReport(val:any){
    return this.http.post(this.APIUrl+'/report', val);
  }

  updateReport(val:any){
    return this.http.put(this.APIUrl+'/report', val);
  }

 /* getAllMedicamentNames():Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+'/Report/GetAll');
  }*/
  
  generate(val:any){
      return this.http.get<any[]>(this.APIUrl+'/sftp');
  }
  
}
