import { Component, Input} from '@angular/core';
import { SubjectSchedule } from 'src/app/core/models/subject-schedules.model';

@Component({
  selector: 'app-semester-load',
  templateUrl: './semester-load.component.html',
  styleUrls: ['./semester-load.component.css']
})
export class SemesterLoadComponent {
  @Input() semesterNumber: number = 1;
  @Input() semesterLoad : SubjectSchedule;

  constructor(){
    this.semesterLoad.semester = this.semesterNumber;
  }
}
