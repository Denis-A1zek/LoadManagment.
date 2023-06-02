import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IPosition } from '../models/position.model';
import { IResult } from '../models/result.model';
import {Observable, delay, retry, tap} from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class DepartmentInfoService {

  positions : IPosition[];

  constructor(private http: HttpClient) { }

  getAllPositions() : Observable<IResult<IPosition[]>>{
    return this.http.get<IResult<IPosition[]>>(environment.apiUrl.concat('positions'))
      .pipe(
        delay(100),
        retry(2),
        tap(result => {
          if(!result.isSuccess) {}
          this.positions = result.payload;
        })
      )
  }
}
