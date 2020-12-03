import { Component, OnInit, Input } from '@angular/core';
import { DirectorServiceService } from 'src/app/director-service.service';
import { Report } from 'src/app/models/report';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {

  constructor(public service:DirectorServiceService, private toastr : ToastrService) { }

  @Input() rep:Report;
  id:number;
  medicamentId:number;
  medicamentName:string;
  quantity:number;
  fromDate:Date;
  toDate:Date;

  //ReportList : Report[];

  ngOnInit(): void {
    this.id = this.rep.id;
    this.medicamentId = this.rep.medicamentId;
    this.medicamentName = this.rep.medicamentName;
    this.quantity = this.rep.quantity;
    this.fromDate = this.rep.fromDate;
    this.toDate = this.rep.toDate;
  }

  addReport(){
    var val = {id:this.rep.id,
      medicamentId:this.rep.medicamentId,
      medicamentName:this.rep.medicamentName,
      quantity:this.rep.quantity,
      fromDate:this.rep.fromDate,
      toDate:this.rep.toDate};

    this.service.addReport(val).subscribe(res=>{
      alert(res.toString())});
      this.toastr.success('Successfully added report!');
  }
}
