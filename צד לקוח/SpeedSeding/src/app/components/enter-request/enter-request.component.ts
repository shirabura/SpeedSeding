import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Address } from 'ngx-google-places-autocomplete/objects/address';


@Component({
  selector: 'app-enter-request',
  templateUrl: './enter-request.component.html',
  styleUrls: ['./enter-request.component.css']
})
export class EnterRequestComponent implements OnInit {
enterreqwestForm:any
  constructor() { }

  ngOnInit(): void {
    this.enterreqwestForm = new FormGroup(
      {
        tz: new FormControl(''),
        date: new FormControl(''),
        hour: new FormControl(''),
        sourceadress: new FormControl(''),
        destinationadress: new FormControl(''),
        
  
       }
     )
  }
  handleDestinationChange(a: Address) {
    console.log(a)
  }


}
