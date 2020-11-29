import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})

export class DirectorServiceService {
  readonly APIUrl = "http://localhost:51492/api";

  constructor(private http:HttpClient) { }

  addReport(val:any){
    return this.http.post(this.APIUrl+'/report', val);
  }

  updateReport(val:any){
    return this.http.put(this.APIUrl+'/report', val);
  }

  generate(val:any){
      return this.http.get<any[]>(this.APIUrl+'/sftp');
  }
}
