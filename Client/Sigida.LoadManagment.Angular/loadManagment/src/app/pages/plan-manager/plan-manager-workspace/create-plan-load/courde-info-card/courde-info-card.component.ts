import { Component, Input } from '@angular/core';
import { SubjectSchedule } from 'src/app/core/models/subject-schedules.model';

@Component({
  selector: 'app-courde-info-card',
  templateUrl: './courde-info-card.component.html',
  styleUrls: ['./courde-info-card.component.css']
})
export class CourdeInfoCardComponent {
  @Input() course : SubjectSchedule;
}
