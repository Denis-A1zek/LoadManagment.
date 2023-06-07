import { SubjectSchedule } from "./subject-schedules.model";

export class Course{
  firstSemester : SubjectSchedule;
  secondSemester : SubjectSchedule;

  constructor(firstSemester : SubjectSchedule, secondSemester : SubjectSchedule){
    this.firstSemester = firstSemester;
    this.secondSemester = secondSemester;
  }
}