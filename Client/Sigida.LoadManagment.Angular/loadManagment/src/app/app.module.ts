import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeComponent } from './pages/employee/employee.component';
import { NavigationComponent } from './shared/navigation/navigation.component';
import { EmployeeListComponent } from './pages/employee/employee-list/employee-list.component';
import { ModalComponent } from './shared/modal/modal.component';
import { CreateEmployeeComponent } from './pages/employee/create-employee/create-employee.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UpdateEmployeeComponent } from './pages/employee/update-employee/update-employee.component';
import { SubjectPageComponent } from './pages/subject-page/subject-page.component';
import { SubjectListComponent } from './pages/subject-page/subject-list/subject-list.component';
import { CreateSubjectComponent } from './pages/subject-page/create-subject/create-subject.component';
import { UpdateSubjectComponent } from './pages/subject-page/update-subject/update-subject.component';
import { PlansPageComponent } from './pages/plans-page/plans-page.component';
import { PlanManagementPageComponent } from './pages/plan-management-page/plan-management-page.component';
import { PlanLoadCardComponent } from './pages/plan-management-page/plan-load-card/plan-load-card.component';
import { PlanCardComponent } from './pages/plans-page/plan-card/plan-card.component';
import { CreatePlanComponent } from './pages/plans-page/create-plan/create-plan.component';
import { DropdownComponent } from './shared/dropdown/dropdown.component';



@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent,
    NavigationComponent,
    EmployeeListComponent,
    ModalComponent,
    CreateEmployeeComponent,
    UpdateEmployeeComponent,
    SubjectPageComponent,
    SubjectListComponent,
    CreateSubjectComponent,
    UpdateSubjectComponent,
    PlansPageComponent,
    PlanManagementPageComponent,
    PlanLoadCardComponent,
    PlanCardComponent,
    CreatePlanComponent,
    DropdownComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
