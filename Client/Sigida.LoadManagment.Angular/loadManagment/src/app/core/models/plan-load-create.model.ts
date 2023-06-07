import { ISubjectSchedules, SubjectSchedule } from "./subject-schedules.model";

export interface IPlanLoadCreateDto{
  subjectId?: string,
  specialtyId?: string,
  subjectSchedules?: ISubjectSchedules[];
}

export class PlanLoadCreateDto{
  subjectId: string = ' ';
  specialtyId: string = ' ';
  subjectSchedule: SubjectSchedule[] = [];

  constructor() {
    this.subjectId = '';
    this.specialtyId = '';
    this.subjectSchedule = [];
  }
}