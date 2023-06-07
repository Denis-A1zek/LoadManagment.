import { ISubjectSchedules } from "./subject-schedules.model";

export interface IPlanLoadViewModel{
  id?: string,
  planId?: string,
  subjectId?: string,
  subjectCode?: string,
  subjectName?: string,
  specialtyId?: string,
  specialtyCode?: string,
  specialtyName?: string,
  subjectSchedule?: ISubjectSchedules[];
}