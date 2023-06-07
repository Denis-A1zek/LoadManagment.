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

import { PlanCardComponent } from './pages/plans-page/plan-card/plan-card.component';
import { CreatePlanComponent } from './pages/plans-page/create-plan/create-plan.component';
import { DropdownComponent } from './shared/dropdown/dropdown.component';

import { PlanManagerComponent } from './pages/plan-manager/plan-manager.component';
import { PlanManagerWorkspaceComponent } from './pages/plan-manager/plan-manager-workspace/plan-manager-workspace.component';
import { PlanLoadCardComponent } from './pages/plan-manager/plan-load-card/plan-load-card.component';
import { CreatePlanLoadComponent } from './pages/plan-manager/plan-manager-workspace/create-plan-load/create-plan-load.component';
import { SemesterLoadComponent } from './pages/plan-manager/plan-manager-workspace/create-plan-load/semester-load/semester-load.component';
import { CourdeInfoCardComponent } from './pages/plan-manager/plan-manager-workspace/create-plan-load/courde-info-card/courde-info-card.component';
import { FilterLoadPipe } from './core/pipes/filter-load.pipe';



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
    PlanCardComponent,
    CreatePlanComponent,
    DropdownComponent,
    PlanManagerComponent,
    PlanManagerWorkspaceComponent,
    PlanLoadCardComponent,
    CreatePlanLoadComponent,
    SemesterLoadComponent,
    CourdeInfoCardComponent,
    FilterLoadPipe
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
