import { Component, Input } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { EditablePlan } from 'src/app/core/models/editable-plan.model';
import { IPlanLoadViewModel } from 'src/app/core/models/plan-load.model';

@Component({
  selector: 'app-plan-load-card',
  templateUrl: './plan-load-card.component.html',
  styleUrls: ['./plan-load-card.component.css']
})
export class PlanLoadCardComponent {
  @Input()  planLoad : IPlanLoadViewModel;
}
