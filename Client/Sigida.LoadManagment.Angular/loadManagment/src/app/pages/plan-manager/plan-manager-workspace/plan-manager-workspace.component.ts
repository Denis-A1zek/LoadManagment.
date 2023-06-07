import { Component } from '@angular/core';
import { result } from 'lodash';
import { Observable } from 'rxjs';
import { IResult } from 'src/app/core/models/result.model';
import { ISpecialty } from 'src/app/core/models/specialty.model';
import { ISubject } from 'src/app/core/models/subject.model';
import { DepartmentInfoService } from 'src/app/core/services/department-info.service';
import { LoadPlannerService } from 'src/app/core/services/load-planner.service';
import { ModalService } from 'src/app/core/services/modal.service';
import { SubjectService } from 'src/app/core/services/subject.service';

@Component({
  selector: 'app-plan-manager-workspace',
  templateUrl: './plan-manager-workspace.component.html',
  styleUrls: ['./plan-manager-workspace.component.css']
})
export class PlanManagerWorkspaceComponent {

  specialities : ISpecialty[];
  subjects : ISubject[];

  constructor(public loadPlannerService : LoadPlannerService, public deparmantInfoService : DepartmentInfoService,
    public subjectService : SubjectService, public modalService : ModalService){
      this.deparmantInfoService.getAllSpecialities().subscribe(response =>{
        if(response.isSuccess){
          this.specialities = response.payload;
        }
      });
      this.subjectService.getAll().subscribe(response =>{
        if(response.isSuccess){
          this.subjects = response.payload;
        }
      });
    }

    onSelectChange(){
      let subjectId = this.loadPlannerService.editablePlan$.value.subjectId;
      const subjectInArray = this.subjects.find(x => x.id === subjectId);
      this.loadPlannerService.editablePlan$.value.subjectName 
      = `${subjectInArray?.code ?? 'Код'} ${subjectInArray?.name ?? 'Название'}`;

      let specialtyId = this.loadPlannerService.editablePlan$.value.specialtyId;
      const specialtyInArray = this.specialities.find(x => x.id === specialtyId);
      this.loadPlannerService.editablePlan$.value.specialtyName 
      = `${specialtyInArray?.code ?? "Код"} ${specialtyInArray?.name ?? "Название"}`;
    }
}
