import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription, tap } from 'rxjs';
import { IPlanViewModel } from 'src/app/core/models/plan.model';

@Component({
  selector: 'app-plan-management-page',
  templateUrl: './plan-management-page.component.html',
  styleUrls: ['./plan-management-page.component.css']
})
export class PlanManagementPageComponent implements OnInit{
  
  editablePlanId : any;
  editablePlan : IPlanViewModel

  private routeSub: Subscription;

  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.routeSub = this.route.params.pipe(
      tap(id => console.log(id))
    ).subscribe(params => {
      this.editablePlan = params['id']; 
    });
    
  }
  
}
