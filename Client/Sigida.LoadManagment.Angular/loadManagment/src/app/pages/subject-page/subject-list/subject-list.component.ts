import { Component, Input } from '@angular/core';
import { ISubject } from 'src/app/core/models/subject.model';
import { ModalService } from 'src/app/core/services/modal.service';
import { SubjectService } from 'src/app/core/services/subject.service';

@Component({
  selector: 'app-subject-list',
  templateUrl: './subject-list.component.html',
  styleUrls: ['./subject-list.component.css'],
  providers: [ModalService]
})
export class SubjectListComponent {
  
  editingSubject : ISubject;

  constructor(public subjectService : SubjectService,
    public modalService: ModalService){}

  @Input() subjects: ISubject[];

  update(subject : ISubject){
    console.log(subject);
    this.editingSubject = subject
    this.modalService.open();
  }
}
