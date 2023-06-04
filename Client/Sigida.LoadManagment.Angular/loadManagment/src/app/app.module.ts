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
import { HomePageComponent } from './pages/home-page/home-page.component';
import { SubjectPageComponent } from './pages/subject-page/subject-page.component';
import { SubjectListComponent } from './pages/subject-page/subject-list/subject-list.component';
import { CreateSubjectComponent } from './pages/subject-page/create-subject/create-subject.component';
import { UpdateSubjectComponent } from './pages/subject-page/update-subject/update-subject.component';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent,
    NavigationComponent,
    EmployeeListComponent,
    ModalComponent,
    CreateEmployeeComponent,
    UpdateEmployeeComponent,
    HomePageComponent,
    SubjectPageComponent,
    SubjectListComponent,
    CreateSubjectComponent,
    UpdateSubjectComponent
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
