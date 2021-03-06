import { Component, OnInit } from '@angular/core';
import { DirectorServiceService } from 'src/app/director-service.service';
import { Report } from '../models/Report';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-director',
  templateUrl: './director.component.html',
  styleUrls: ['./director.component.css']
})
export class DirectorComponent implements OnInit {

  constructor(private service:DirectorServiceService, private router: Router, public snackBar: MatSnackBar) { }

  medicamentName:string;
  quantity:number;
  fromDate:Date;
  toDate:Date;

  ReportList: Report[];

  ModalTitle:string;
  ActivateAddEditRepComp:boolean=false;
  rep:Report;
  val:any;

  ngOnInit(): void {
    this.refreshReportList();
  }

  addclick(){
    this.rep={
      medicamentName:"",
      quantity: 0,
      fromDate: null,
      toDate: null
    }
    this.ModalTitle="Add Report";
    this.ActivateAddEditRepComp=true;
  }

  closeClick(){
    this.ActivateAddEditRepComp=false;
    this.refreshReportList();
  }

  refreshReportList(){
    this.service.getReportList().subscribe((data: Report[]) => {
      console.log(data);
      this.ReportList = data;
    }),
    error => {
     //console.log("Report list is not possible to load because server isn't responding.");
    };
  }

  generate(){
    this.service.generate(this.val).subscribe(data => {
      alert("Report saved!");
      console.log(this.ReportList);
    })
  }

  publishT(){
    this.service.publishTender().subscribe(data=>{
      console.log("Successfully sent!");
      alert("Successfully sent!");
    },
    error => {
     //console.log("");
    });
  }

  showOffers(){
    this.router.navigate(['showOffers']);
  }

  closeT(){
    this.router.navigate(['closeTender']);
  }

  urgent(){
    this.router.navigate(['urgentProcurement']);
  }
}
