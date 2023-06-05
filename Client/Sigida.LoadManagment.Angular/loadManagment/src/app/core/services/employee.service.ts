import { Injectable, Input } from '@angular/core';
import { IEmployee } from '../models/employee.model';
import { environment } from "src/environments/environment";
import { Observable, delay, tap, retry, firstValueFrom,  } from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpParams } from "@angular/common/http"
import { IResult } from '../models/result.model';
import { IEmployeeEdit } from '../models/employee-edit.model';
import { IEmployeeDto } from '../models/employee-create.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  employees: IEmployee[];
  
  constructor(private http: HttpClient) { }

  getAll() : Observable<IResult<IEmployee[]>>{
    return this.http.get<IResult<IEmployee[]>>(environment.apiUrl.concat('employees'))
      .pipe(
        tap(result => this.employees = result.payload)
      )
  }

  create(employee : IEmployeeDto) : Observable<IEmployeeDto>{
    return this.http.post<IEmployeeDto>(environment.apiUrl.concat('employee'), employee)
      .pipe(
        tap(result => {
          this.getById(result).then(response => 
            this.employees.push(response))
        })
      )
  }

  async getById(id : any) : Promise<IEmployee>{
    var newEmployee: IEmployee;
    var result = await firstValueFrom(this.http
      .get<IResult<IEmployee>>(environment.apiUrl.concat('employee/') + id.payload));
    if(!result.isSuccess){
      console.log("Ошибка при получении пользователя по id");
    }
    return result.payload;
  }

  async delete(id : any) : Promise<boolean>{
    var result = await firstValueFrom
      (this.http.delete<IResult<string>>(environment.apiUrl.concat('employee/') + id));
    
    if(result.isSuccess){
      this.employees.splice(this.employees.findIndex(x => x.id == result.payload), 1);
      return true
    }

    return false;
  }

  getForEdit(id : any) : Observable<IResult<IEmployeeEdit>>{
    return this.http.get<IResult<IEmployeeEdit>>(environment.apiUrl.concat('employee/edit/') + id)
      .pipe(
        tap(result => {
          if(!result.isSuccess){
            console.log("Не удалось получить сотрудника для редактирования " + id)
          }
        })
      )
  }

  update(employee : IEmployeeEdit) : Observable<IResult<any>>{
    return this.http.put<IResult<any>>(environment.apiUrl.concat('employee'), employee).pipe(
      tap(result => {
        this.getById(result).then(response => 
          this.employees[this.employees.findIndex(x => x.id == result.payload)] = response)
      })
    );
  }

}
