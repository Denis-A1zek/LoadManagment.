import { Pipe, PipeTransform } from '@angular/core';
import { EditablePlan } from '../models/editable-plan.model';
import { SubjectSchedule } from '../models/subject-schedules.model';
import { Course } from '../models/course.model';


@Pipe({
  name: 'filterLoad'
})
export class FilterLoadPipe implements PipeTransform {

  transform(subjectSchedule: SubjectSchedule[], course: number): Course {
    var values = subjectSchedule.filter(p => p.course === course);
    return new Course(values[0], values[1]);
  }

}