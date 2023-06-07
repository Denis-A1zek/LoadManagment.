import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription, tap } from 'rxjs';
import { IPlanLoadViewModel } from 'src/app/core/models/plan-load.model';
import { IResult } from 'src/app/core/models/result.model';
import { LoadPlannerService } from 'src/app/core/services/load-planner.service';
import { PlanLoadService } from 'src/app/core/services/plan-load.service';
import { PlanService } from 'src/app/core/services/plan.service';

@Component({
  selector: 'app-plan-manager',
  templateUrl: './plan-manager.component.html',
  styleUrls: ['./plan-manager.component.css']
})
export class PlanManagerComponent implements OnInit{
  
  public isLoadsLoading : boolean = false;
  private routeSub: Subscription;

  public loads$ : Observable<IResult<IPlanLoadViewModel[]>>;

  constructor(public loadPlannerService : LoadPlannerService, private route: ActivatedRoute,
    private planService : PlanService, public planloadService : PlanLoadService){
  }

  async ngOnInit(): Promise<void> {
    this.routeSub = this.route.params.pipe(
      tap(id => console.log(id))
    ).subscribe(params => {
      this.loadPlannerService.create(params['id']); 
    });

    this.loadPlannerService.editablePlan$.subscribe(result => console.log(result));
    let plan = await this.planService.getById(this.loadPlannerService.editablePlan$.value.planId);
    this.loadPlannerService.editablePlan$.value.planName = plan.title;

    this.loads$ = this.planloadService.getPlanDetailsByPlanId(this.loadPlannerService.editablePlan$.value.planId);
  }

}
