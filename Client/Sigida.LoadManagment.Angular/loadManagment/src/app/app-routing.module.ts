import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './pages/employee/employee.component';
import { SubjectPageComponent } from './pages/subject-page/subject-page.component';
import { PlansPageComponent } from './pages/plans-page/plans-page.component';
import { PlanManagerComponent } from './pages/plan-manager/plan-manager.component';

const routes: Routes = [
  {path: '', component: PlansPageComponent},
  {path: 'employees', component: EmployeeComponent},
  {path: 'plan/:id', component: PlanManagerComponent},
  {path: 'subjects', component: SubjectPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
