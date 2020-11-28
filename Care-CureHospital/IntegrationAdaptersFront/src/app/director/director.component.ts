import { Component, OnInit } from '@angular/core';
import { DirectorServiceService } from 'src/app/director-service.service';

@Component({
  selector: 'app-director',
  templateUrl: './director.component.html',
  styleUrls: ['./director.component.css']
})
export class DirectorComponent implements OnInit {

  constructor(private service:DirectorServiceService) { }

  MedicationList:any=[];

  ModalTitle:string;
  ActivateAddEditRepComp:boolean=false;
  rep:any;

  ngOnInit(): void {
   // this.refreshMedList();
  }


  addclick(){
    this.rep={
      MedicationId:0,
      MedicationName:"",
      MedicationLeft:"",
      Date:""


    }
    this.ModalTitle="Add Report";
    this.ActivateAddEditRepComp=true;

  }

  closeClick(){
    this.ActivateAddEditRepComp=false;
    
  }

  /*refreshMedList(){
    this.service.getMedList().subscribe(data=>{this.MedicationList=data;});

  }*/


  saveTxt(){
    
  }

}
