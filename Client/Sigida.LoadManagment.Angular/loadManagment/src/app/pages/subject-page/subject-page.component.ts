import { Component, OnInit } from '@angular/core';
import { ModalService } from 'src/app/core/services/modal.service';
import { SubjectService } from 'src/app/core/services/subject.service';

@Component({
  selector: 'app-subject-page',
  templateUrl: './subject-page.component.html',
  styleUrls: ['./subject-page.component.css']
})
export class SubjectPageComponent implements OnInit{
  
  isLoading = false;

  constructor(public subjectService : SubjectService,
    public modalService: ModalService){

  }
  ngOnInit(): void {
    this.isLoading = true;
    this.subjectService.getAll().subscribe(() =>
      this.isLoading = false)
  }

}
