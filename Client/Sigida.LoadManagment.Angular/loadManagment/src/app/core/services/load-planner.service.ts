import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, filter, map} from 'rxjs';
import { SubjectSchedule } from '../models/subject-schedules.model';
import { EditablePlan } from '../models/editable-plan.model';
import { Course } from '../models/course.model';

@Injectable({
  providedIn: 'root'
})
export class LoadPlannerService {
  
  editablePlan$ : BehaviorSubject<EditablePlan>;

  create(planId : any) : Observable<EditablePlan> {
    let editable = new EditablePlan(planId,'New Plan','', 'Специальность...', '', 'Предмет...');
    return this.editablePlan$ = new BehaviorSubject<EditablePlan>(editable);
  }

  addSubjectSchedule(subjectSchedule : SubjectSchedule){
    this.editablePlan$.value.loads.push(subjectSchedule);
  }
  // getLoads(number : number) : Observable<Course>{
  //   var result = this.editablePlan$.
  //     pipe(
  //       filter((result) => {
  //         const values = result.loads.filter(x => x.course === number);
  //         const course = new Course(values[0], values[1]);
  //         return course;
  //       })
  //     );

  //   value.loads.find(x => x.course === number)
  // }

}