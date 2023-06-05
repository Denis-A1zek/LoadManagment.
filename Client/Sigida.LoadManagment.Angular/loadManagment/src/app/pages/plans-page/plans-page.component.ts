import { Component, OnInit } from '@angular/core';
import { ModalService } from 'src/app/core/services/modal.service';
import { PlanService } from 'src/app/core/services/plan.service';

@Component({
  selector: 'app-plans-page',
  templateUrl: './plans-page.component.html',
  styleUrls: ['./plans-page.component.css']
})
export class PlansPageComponent implements OnInit{

  isLoading = false;

  constructor(public modalService : ModalService,
    public planService : PlanService){
    
  }
  ngOnInit(): void {
    this.isLoading = true;
    this.planService.getAllPlans().subscribe(result =>{
      if(!result.isSuccess){
        console.log("Не удалось получить данные о планах с сервера");
        return;
      }
      this.isLoading = false;
    })
  }
}
