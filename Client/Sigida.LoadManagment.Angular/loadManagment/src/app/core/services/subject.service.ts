import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, retry, tap, delay, firstValueFrom} from 'rxjs';
import { ISubject } from '../models/subject.model';
import { IResult } from '../models/result.model';
import { environment } from 'src/environments/environment';
import { ISubjectDto } from '../models/subject-create.model';


@Injectable({
  providedIn: 'root'
})
export class SubjectService {
  
  subjects : ISubject[];

  constructor(private http: HttpClient) { }

  getAll() : Observable<IResult<ISubject[]>>{
    return this.http.get<IResult<ISubject[]>>(environment.apiUrl.concat('subjects'))
      .pipe(
        delay(500),
        retry(2),
        tap(result => this.subjects = result.payload)
      )
  }

  create(subject : ISubjectDto) : Observable<IResult<any>>{
    return this.http.post<IResult<any>>(environment.apiUrl.concat('subject'), subject)
      .pipe(
        tap(result => {
          this.getById(result).then(response => 
            this.subjects.push(response))
        })
      )
  }

  async getById(id : any) : Promise<ISubject>{
    var result = await firstValueFrom(this.http
      .get<IResult<ISubject>>(environment.apiUrl.concat('subject/') + id.payload));
    if(!result.isSuccess){
      console.log("Ошибка при получении пользователя по id");
    }
    return result.payload;
  }

  async delete(id : any) : Promise<boolean>{
    var result = await firstValueFrom
    (this.http.delete<IResult<string>>(environment.apiUrl.concat('subject/') + id)); 
    
    if(result.isSuccess){
      this.subjects.splice(this.subjects.findIndex(x => x.id == result.payload), 1);
      return true
    }

    return false;
  }

  update(subject : ISubject) : Observable<IResult<any>>{
    return this.http.put<IResult<any>>(environment.apiUrl.concat('subject'), subject).pipe(
      tap(response => {
        if(response.isSuccess){
          this.subjects[this.subjects.findIndex(x => x.id == subject.id)] = subject;
          return;
        }
        console.log("НЕ УДАЛОСЬ ОБНОВИТЬ ОБЪЕКТ" + subject);
      })
    )
  }

}