import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './pages/employee/employee.component';
import { SubjectPageComponent } from './pages/subject-page/subject-page.component';
import { PlansPageComponent } from './pages/plans-page/plans-page.component';
import { PlanManagementPageComponent } from './pages/plan-management-page/plan-management-page.component';

const routes: Routes = [
  {path: '', component: PlansPageComponent},
  {path: 'employees', component: EmployeeComponent},
  {path: 'plan/:id', component: PlanManagementPageComponent},
  {path: 'subjects', component: SubjectPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
