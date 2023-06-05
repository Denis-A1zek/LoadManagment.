import { Component } from '@angular/core';
import { PlanService } from 'src/app/core/services/plan.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { isNull } from 'lodash';
import { ModalService } from 'src/app/core/services/modal.service';

@Component({
  selector: 'app-create-plan',
  templateUrl: './create-plan.component.html',
  styleUrls: ['./create-plan.component.css']
})
export class CreatePlanComponent {

  form = new FormGroup({
    title: new FormControl<string>('', [
      Validators.required,
      Validators.minLength(2)
    ]),
    description: new FormControl<string>('', [
      Validators.minLength(2)
    ]),
    start: new FormControl<Date | null>(null),
    end: new FormControl<Date | null>(null)
  })

  constructor(public planService : PlanService, 
    private modalService : ModalService){
  }

  submit(){
    console.log(this.form);
    this.planService.create({
      title: this.form.value.title as string,
      description: this.form.value.description as string,
      start: this.form.value.start as Date,
      end: this.form.value.end as Date
    }).subscribe(() => this.modalService.close());
  }


}
