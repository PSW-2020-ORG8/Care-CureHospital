import { Component, OnInit } from '@angular/core';
import { DirectorServiceService } from 'src/app/director-service.service';
import { Report } from 'src/app/models/report';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

export interface DataOfReport {
  id: number;
  medicationId: number;
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

  constructor(private service : DirectorServiceService,
    private toastr : ToastrService) { }

  ReportList : Report[];

  ModalTitle:string;
  ActivateAddEditRepComp:boolean=false;
  rep:Report;

  ngOnInit(): void {
    this.refreshReportList();
  }

  addclick(){
    this.rep={
      id:0,
      medicamentId:0,
      medicamentName:"",
      quantity:0,
      fromDate:null,
      toDate:null
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
   });
  }

  generate(){
    this.toastr.success('Report saved!');
  }

 /* deleteReport(id){
    this.service.deleteReport(id).subscribe(res => {
      console.log(res);  
      alert(res.toString());
      this.toastr.success('Deleted successfully!');
    },
    error => console.log(error));
  }*/
    
  }
