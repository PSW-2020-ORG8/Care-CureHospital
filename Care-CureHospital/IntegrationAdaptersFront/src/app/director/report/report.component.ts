import { Component, OnInit, Input } from '@angular/core';
import { DirectorServiceService } from 'src/app/director-service.service';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {

  constructor(private service:DirectorServiceService) { }

  @Input() rep:any;
  id:number;
  medicamentId: number;
  medicamentName:string;
  quantity:number;
  fromDate:Date;
  toDate:Date;

  ReportList:any=[];

  ngOnInit(): void {
  }

  addReport(){
    var val = {id:this.id,
              medicamentId:this.medicamentId,
              medicamentName:this.medicamentName,
              quantity:this.quantity,
              fromDate:this.fromDate,
              toDate:this.toDate};

    this.service.addReport(val).subscribe(res=>{
      alert(res.toString())});
    alert("Successfully added report");
  }
}
