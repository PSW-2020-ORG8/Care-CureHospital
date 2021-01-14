import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-show-offer',
  templateUrl: './show-offer.component.html',
  styleUrls: ['./show-offer.component.css']
})
export class ShowOfferComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  activeTender(){
    this.router.navigate(['activeTender']);
  }

  inactiveTender(){
    this.router.navigate(['inactiveTender']);
  }
}
