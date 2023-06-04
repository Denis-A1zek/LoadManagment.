import { Component, OnInit , Input} from '@angular/core';
import { Subject } from 'rxjs';
import { ISubject } from 'src/app/core/models/subject.model';
import { cloneDeep } from 'lodash';
import { SubjectService } from 'src/app/core/services/subject.service';
import { ModalService } from 'src/app/core/services/modal.service';

@Component({
  selector: 'app-update-subject',
  templateUrl: './update-subject.component.html',
  styleUrls: ['./update-subject.component.css'],
})
export class UpdateSubjectComponent implements OnInit {
  
  @Input() editingSubject: ISubject;

  isLoading = false;
  editingSubjectNew : ISubject;

  constructor(public subjectService : SubjectService,
    private modalService : ModalService){

  }

  ngOnInit(): void {
    this.editingSubjectNew = cloneDeep(this.editingSubject);
  }

  update(){
    console.log(this.editingSubject);
    this.subjectService.update(this.editingSubjectNew).subscribe(response =>{
      if(response.isSuccess){
        this.modalService.close();
        return;
      }
    })
  }
}
