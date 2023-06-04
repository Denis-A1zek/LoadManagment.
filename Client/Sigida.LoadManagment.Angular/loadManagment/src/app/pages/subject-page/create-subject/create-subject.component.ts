import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalService } from 'src/app/core/services/modal.service';
import { SubjectService } from 'src/app/core/services/subject.service';

@Component({
  selector: 'app-create-subject',
  templateUrl: './create-subject.component.html',
  styleUrls: ['./create-subject.component.css']
})
export class CreateSubjectComponent {
  
  constructor(public subjectService : SubjectService,
    private modalService : ModalService){
  }

  form = new FormGroup({
    code: new FormControl<string>('', [
      Validators.required,
      Validators.minLength(6)
    ]),
    name: new FormControl<string>('', [
      Validators.required,
      Validators.minLength(6)
    ])
  })

  submit(){
    this.subjectService.create({
      code: this.form.value.code as string,
      name: this.form.value.name as string
    }).subscribe(() => this.modalService.close());
  }

}
