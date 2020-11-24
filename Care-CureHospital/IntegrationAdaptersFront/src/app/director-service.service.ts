import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class DirectorServiceService {
  readonly APIUrl = "http://localhost:51492/api";

  constructor(private http:HttpClient) { }

  getMedList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/getAll');
  }

  addReport(val:any){
    return this.http.post(this.APIUrl+'/Repost', val);
  }
  
}
