export interface ISubjectSchedules{
  course: number,
  semester: number,
  lectureHours: number,
  labHour: number,
  practiceHours: number,
  selfHours: number,
  id: string
}

export class SubjectSchedule{
  course: number = 0;
  semester: number = 0;
  lectureHours: number = 0;
  labHours: number = 0;
  practiceHours: number = 0;
  selfHours: number = 0;

  constructor(course: number, semester: number, 
    lectureHours: number, labHour: number, 
    practiceHours: number, selfHours: number){
    this.course = course;
    this.semester = semester;
    this.lectureHours = lectureHours;
    this.labHours = labHour;
    this.practiceHours = practiceHours;
    this.selfHours = selfHours;
  }
}