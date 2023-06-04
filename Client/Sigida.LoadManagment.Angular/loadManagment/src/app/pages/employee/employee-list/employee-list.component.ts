import { Component, Input } from '@angular/core';
import { IEmployeeEdit } from 'src/app/core/models/employee-edit.model';
import { IEmployee } from 'src/app/core/models/employee.model';
import { EmployeeService } from 'src/app/core/services/employee.service';
import { ModalService } from 'src/app/core/services/modal.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
  providers: [ModalService]
})
export class EmployeeListComponent {

  editedEmployeeId : any;

  constructor(public employeeService : EmployeeService,
    public modalService : ModalService){   
  }

  @Input() employees: IEmployee[];

  editUser(id:any){
    this.editedEmployeeId = id;
    this.modalService.open();
  }
}
