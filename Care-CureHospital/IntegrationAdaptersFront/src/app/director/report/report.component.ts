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
  MedicationId:string;
  MedicationName:string;
  Date:string;

  MedicationList:any=[];

  ngOnInit(): void {
    //.loadMedicationList();
  }

  /*loadMedicationList(){
    this.service.getMedList().subscribe((data:any)=>{
      this.MedicationList=data;
    });
  }

  addReport(){
    var val = {MedicationId:this.MedicationList, 
              MedicationName:this.MedicationName};

    this.service.addReport(val).subscribe(res=>{alert(res.toString())});
    alert("abgdfvdsa");
  }*/

}
