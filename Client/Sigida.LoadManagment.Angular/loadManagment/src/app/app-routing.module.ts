import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './pages/employee/employee.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { SubjectPageComponent } from './pages/subject-page/subject-page.component';

const routes: Routes = [
  {path: '', component: HomePageComponent},
  {path: 'employees', component: EmployeeComponent},
  {path: 'subjects', component: SubjectPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
