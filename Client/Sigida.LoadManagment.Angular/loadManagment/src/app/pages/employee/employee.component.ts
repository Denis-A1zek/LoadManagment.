import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/core/services/employee.service';
import { ModalService } from 'src/app/core/services/modal.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit{
  
  isLoading = false;

  constructor(public employeeService : EmployeeService,
    public modalService: ModalService){

  }
  ngOnInit(): void {
    this.isLoading = true;
    this.employeeService.getAll().subscribe(() =>
      this.isLoading = false)
  }
}
