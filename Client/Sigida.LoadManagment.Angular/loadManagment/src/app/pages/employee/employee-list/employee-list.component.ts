import { Component, Input } from '@angular/core';
import { IEmployee } from 'src/app/core/models/employee.model';
import { EmployeeService } from 'src/app/core/services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent {

  constructor(public employeeService : EmployeeService){
    
  }

  @Input() employees: IEmployee[];
}
