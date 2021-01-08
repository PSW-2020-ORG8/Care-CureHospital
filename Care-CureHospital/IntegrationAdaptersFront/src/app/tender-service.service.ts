import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { Offer } from './models/Offer';
import { Tender } from './models/Tender';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TenderServiceService {
  readonly APIUrl = "http://localhost:51999/api";

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

  chooseTender(){
    return this.http.get<any[]>(this.APIUrl+'/offer/winner');
  }

  /*closeTender():Observable<any>{
    return this.http.put<any>(this.APIUrl+'/tender/closeTender'); //'offer/notWinner
  }*/

  closeTender(val:any){
    return this.http.put(this.APIUrl+'/tender/closeTender/{tenderId}', val);
  }
}
