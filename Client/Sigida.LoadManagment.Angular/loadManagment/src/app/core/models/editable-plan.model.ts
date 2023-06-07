import { SubjectSchedule } from "./subject-schedules.model";

export class EditablePlan{

  planId : any;
  planName : string
  specialtyId : any;
  specialtyName : string;
  subjectId : any;
  subjectName : string;
  loads : SubjectSchedule[];

  constructor(planId : any, planName : string,specialtyId : any, specialtyName : string,
    subjectId : any, subjectName : string){
      this.planId = planId;
      this.planName = planName;
      this.specialtyId = specialtyId;
      this.specialtyName = specialtyName;
      this.subjectId = subjectId;
      this.subjectName = subjectName;
      this.loads = [];
    }
}