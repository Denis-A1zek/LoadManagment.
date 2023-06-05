import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { IPlanViewModel } from '../models/plan.model';
import { IPlanCreateDto } from '../models/plan-create.model';
import { IResult } from '../models/result.model';
import { environment } from 'src/environments/environment';
import { Observable, delay, tap, retry, firstValueFrom,  } from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpParams } from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class PlanService {
  
  plans : IPlanViewModel[];

  constructor(private http: HttpClient){
  }
  
  getAllPlans(){
    return this.http.get<IResult<IPlanViewModel[]>>(environment.apiUrl.concat('plans'))
      .pipe(
        tap(result => this.plans = result.payload)
      )
  }

  create(plan : IPlanCreateDto) : Observable<IResult<any>>{
    return this.http.post<IResult<any>>(environment.apiUrl.concat('plan'), plan)
      .pipe(
        tap(result => {
          console.log("Получаем объект плана с сервера для обновления" + result.payload)
          this.getById(result.payload).then(response => 
             this.plans.push(response))
        })
      )
  }

  async getById(id : any) : Promise<IPlanViewModel>{
    var result = await firstValueFrom(this.http
      .get<IResult<IPlanViewModel>>(environment.apiUrl.concat('plan/') + id));
    if(!result.isSuccess){
      console.log("Ошибка при получении плана по id");
    }
    return result.payload;
  }

  async delete(id : any) : Promise<boolean>{
    var result = await firstValueFrom
      (this.http.delete<IResult<string>>(environment.apiUrl.concat('plan/') + id));
    
    if(result.isSuccess){
      this.plans.splice(this.plans.findIndex(x => x.id == result.payload), 1);
      return true
    }
    return false;
  }
}