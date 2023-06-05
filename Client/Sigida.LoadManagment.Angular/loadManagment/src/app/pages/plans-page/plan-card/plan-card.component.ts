import { Component, Input } from '@angular/core';
import { IPlanViewModel } from 'src/app/core/models/plan.model';
import { PlanService } from 'src/app/core/services/plan.service';

@Component({
  selector: 'app-plan-card',
  templateUrl: './plan-card.component.html',
  styleUrls: ['./plan-card.component.css']
})
export class PlanCardComponent {
  @Input() plan : IPlanViewModel;

  constructor(public planService : PlanService){}
}
