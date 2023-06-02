import { Component, Input } from '@angular/core';
import { ModalService } from 'src/app/core/services/modal.service';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {

  constructor(public modalService : ModalService){
  }

  log(){
    console.log('Меня нажали')
  }

  @Input() title:string = "Modal";
}
