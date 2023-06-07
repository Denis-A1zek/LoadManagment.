import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { IPlanLoadViewModel } from '../models/plan-load.model';
import { IResult } from '../models/result.model';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { PlanLoadCreateDto } from '../models/plan-load-create.model';

@Injectable({
  providedIn: 'root'
})
export class PlanLoadService {

  planLodsViewModels : IPlanLoadViewModel[];

  constructor(public http: HttpClient){
    
  }

  getPlanDetailsByPlanId(id : any) : Observable<IResult<IPlanLoadViewModel[]>>{
    return this.http.get<IResult<IPlanLoadViewModel[]>>(`${environment.apiUrl}plan/${id}/loads`) 
      .pipe(
        tap(result => this.planLodsViewModels = result.payload)
      )
  }

  create(planId: any ,planLoad : PlanLoadCreateDto) : Observable<IResult<any>>{
    return this.http.post<IResult<any>>(`${environment.apiUrl}plan/${planId}/load`, planLoad)
      .pipe(
        tap(result => {
          if(result.isSuccess){
            
          }
        })
      );
  }
}