import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { Offer } from './models/Offer';
import { Tender } from './models/Tender';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class TenderServiceService {

 readonly APIUrl = "http://localhost:61793/gateway";

  constructor(private http:HttpClient) {
     this.getOfferListActive() ,
     this.getOfferListInactive()
  }

  getOfferListActive():Observable<Offer[]>{
    return this.http.get<Offer[]>(this.APIUrl+'/offer/activeTender').
    pipe(
      map((data: any) => {
        return data;
      }), catchError( error => {
        return throwError( 'Server is not responding!' );
      })
    )
  }

  getOfferListInactive():Observable<Offer[]>{
    return this.http.get<Offer[]>(this.APIUrl+'/offer/inactiveTender').
    pipe(
      map((data: any) => {
        return data;
      }), catchError( error => {
        return throwError( 'Server is not responding!' );
      })
    )
  }

  getActiveTender():Observable<Tender[]>{
    return this.http.get<Tender[]>(this.APIUrl+'/tender/getActiveTender').
    pipe(
      map((data: any) => {
        return data;
      }), catchError( error => {
        return throwError( 'Server is not responding!' );
      })
    )
  }

  chooseTender(id:number):Observable<Offer>{
    return this.http.put<Offer>(this.APIUrl+'/offer/chooseO/'+id, {}).
    pipe(
      map((data: any) => {
        return data;
      }), catchError( error => {
        return throwError( 'You did not choose offer!' );
      })
    )
  }

  closeTender(id:number):Observable<Tender>{
    return this.http.put<Tender>(this.APIUrl+ '/tender/closeTender/'+id, {}).
    pipe(
      map((data: any) => {
        return data;
      }), catchError( error => {
        return throwError( 'You did not choose tender!' );
      })
    )
  }
}
