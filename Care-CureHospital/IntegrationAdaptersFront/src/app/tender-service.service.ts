import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { Offer } from './models/Offer';
import { Tender } from './models/Tender';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class TenderServiceService {

//readonly APIUrl = "http://localhost:50002/api";

 readonly APIUrl = "http://localhost:61793/gateway";


  constructor(private http:HttpClient) {
     this.getOfferListActive() ,
     this.getOfferListInactive()
  }

  getOfferListActive():Observable<Offer[]>{
    return this.http.get<Offer[]>(this.APIUrl+'/offer/activeTender');
  }

  getOfferListInactive():Observable<Offer[]>{
    return this.http.get<Offer[]>(this.APIUrl+'/offer/inactiveTender');
  }

  getActiveTender():Observable<Tender[]>{
    return this.http.get<Tender[]>(this.APIUrl+'/tender/getActiveTender');
  }

  chooseTender(id:number):Observable<Offer>{
    return this.http.put<Offer>(this.APIUrl+'/offer/chooseO/${id}', id);
  }

  closeTender(id:number):Observable<Tender>{
    return this.http.put<Tender>(this.APIUrl+ '/tender/closeTender/{tenderId}', id);
  }
}
