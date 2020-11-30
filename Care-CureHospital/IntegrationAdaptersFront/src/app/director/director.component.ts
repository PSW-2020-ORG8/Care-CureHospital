import { Component, OnInit } from '@angular/core';
import { DirectorServiceService } from 'src/app/director-service.service';

export interface DataOfReport {
  id: string;
  medicationId: string;
  medicationName: string;
  quantity: string;
  fromDate: string;
  toDate: string;
}

@Component({
  selector: 'app-director',
  templateUrl: './director.component.html',
  styleUrls: ['./director.component.css']
})
export class DirectorComponent implements OnInit{

  constructor(private service:DirectorServiceService) { }

  ReportList:any=[];

  ModalTitle:string;
  ActivateAddEditRepComp:boolean=false;
  rep:any;

  ngOnInit(): void {
    this.refreshReportList();
  }

  addclick(){
    this.rep={
      MedicationName:"",
      MedicationLeft:"",
      FromDate:"",
      ToDate:""
    }
    this.ModalTitle="Add Report";
    this.ActivateAddEditRepComp=true;

  }

  closeClick(){
    this.ActivateAddEditRepComp=false;
    this.refreshReportList();
  }

  refreshReportList(){
    this.service.getReportList().subscribe(data=>{this.ReportList=data;});
  }

  generate(){
    alert("Report saved.");
  }
}
