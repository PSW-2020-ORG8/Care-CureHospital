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
  MedicationName:string;
  ConsumedMedication:string;
  FromDate:string;
  ToDate:string;

  ReportList:any=[];

  ngOnInit(): void {
  }

  addReport(){
    var val = {MedicationName:this.MedicationName,
              ConsumedMedication:this.ConsumedMedication,
              FromDate:this.FromDate,
              ToDate:this.ToDate};

    this.service.addReport(val).subscribe(res=>{
      alert(res.toString())});
    alert("Successfully added report");
  }

}
