import { Component, Input, OnInit } from '@angular/core';
import { IEmployeeEdit } from 'src/app/core/models/employee-edit.model';
import { DepartmentInfoService } from 'src/app/core/services/department-info.service';
import { EmployeeService } from 'src/app/core/services/employee.service';
import { ModalService } from 'src/app/core/services/modal.service';

@Component({
  selector: 'app-update-employee',
  templateUrl: './update-employee.component.html',
  styleUrls: ['./update-employee.component.css']
})
export class UpdateEmployeeComponent implements OnInit{
  
  @Input() editingEmployeeId : any;

  isLoading = false;

  editingEmployee : IEmployeeEdit;

  constructor(private employeeService : EmployeeService, 
    public departmentService : DepartmentInfoService,
    private modalService : ModalService){}
  
  ngOnInit(): void {
    this.isLoading = true;
    console.log("Редактируем пользователя" + this.editingEmployeeId)
    this.employeeService.getForEdit(this.editingEmployeeId)
      .subscribe( result =>{
        this.editingEmployee = result.payload
        console.log(this.editingEmployee);
        this.isLoading = false;
      });
      this.departmentService.getAllPositions().subscribe((value) =>
        console.log(value));
  }

  update(){
    console.log(this.editingEmployee)
    this.employeeService.update(this.editingEmployee).subscribe(response =>{
        if(response.isSuccess){
          this.modalService.close();
          return;
        }
        console.log("Не удалось обновить пользователя");
      }
    )
  }

}
