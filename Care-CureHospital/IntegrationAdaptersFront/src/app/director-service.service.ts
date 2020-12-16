import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { Observable } from 'rxjs';
import { Report } from './models/Report';

@Injectable({
  providedIn: 'root'
})

export class DirectorServiceService {
  readonly APIUrl = "http://localhost:51492/api";

  constructor(private http:HttpClient) { this.getReportList() }

  getReportList():Observable<Report[]>{
    return this.http.get<Report[]>(this.APIUrl+'/report');
  }

  addReport(val:Report):Observable<Report>{
    return this.http.post<Report>(this.APIUrl+'/report', val);
  }

  updateReport(val:any){
    return this.http.put(this.APIUrl+'/report', val);
  }

  generate(val:any){
    return this.http.get<any[]>(this.APIUrl+'/sftp');
  }
}
