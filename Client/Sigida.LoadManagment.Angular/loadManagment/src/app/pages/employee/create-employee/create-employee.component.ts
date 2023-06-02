import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DepartmentInfoService } from 'src/app/core/services/department-info.service';
import { EmployeeService } from 'src/app/core/services/employee.service';
import { ModalService } from 'src/app/core/services/modal.service';

@Component({
  selector: 'app-create-employee',
  templateUrl: './create-employee.component.html',
  styleUrls: ['./create-employee.component.css']
})
export class CreateEmployeeComponent implements OnInit {
  
  form = new FormGroup({
    name: new FormControl<string>('', [
      Validators.required,
      Validators.minLength(6)
    ]),
    surName: new FormControl<string>('', [
      Validators.required,
      Validators.minLength(6)
    ]),
    lastName: new FormControl<string>('', [
      Validators.required,
      Validators.minLength(6)
    ]),
    positionId: new FormControl<string>('', [
      Validators.required,
      Validators.minLength(6)
    ]),
  })

  constructor(public departmentService : DepartmentInfoService,
    private employeeService : EmployeeService,
    private modalService : ModalService){
  }
  
  ngOnInit(): void {
    this.departmentService.getAllPositions().subscribe((value) =>
      console.log(value));
  }

  submit(){
    this.employeeService.create({
      name: this.form.value.name as string,
      surName: this.form.value.surName as string,
      lastName: this.form.value.lastName as string,
      positionId: this.form.value.positionId as string
    }).subscribe(() => this.modalService.close());
  }

}
