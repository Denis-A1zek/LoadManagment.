import { Component } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { SubjectSchedule } from 'src/app/core/models/subject-schedules.model';
import { LoadPlannerService } from 'src/app/core/services/load-planner.service';
import { ModalService } from 'src/app/core/services/modal.service';

@Component({
  selector: 'app-create-plan-load',
  templateUrl: './create-plan-load.component.html',
  styleUrls: ['./create-plan-load.component.css']
})
export class CreatePlanLoadComponent {
  
  subjectFirstSemester : SubjectSchedule;
  subjectSecondSemester : SubjectSchedule

  selectedCourse : string = "1";
  courseNumber$ : BehaviorSubject<string> = new BehaviorSubject<string>('');

  constructor(public loadPlannerService : LoadPlannerService,private  modalService : ModalService){
    this.subjectFirstSemester = new SubjectSchedule(1,1,0,0,0,0);
    this.subjectSecondSemester = new SubjectSchedule(1,1,0,0,0,0);
  }

  submit(){
    console.log(this.subjectFirstSemester);
    console.log(this.subjectSecondSemester);
    this.loadPlannerService.addSubjectSchedule(this.subjectFirstSemester);
    this.loadPlannerService.addSubjectSchedule(this.subjectSecondSemester);
    this.modalService.close();
  }

  onStringChange(){
    this.subjectFirstSemester.course = parseInt(this.selectedCourse);
    this.subjectSecondSemester.course = parseInt(this.selectedCourse);
  }
}
