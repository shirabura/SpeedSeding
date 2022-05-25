import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Address } from 'ngx-google-places-autocomplete/objects/address';

@Component({
  selector: 'app-possibledrive',
  templateUrl: './possibledrive.component.html',
  styleUrls: ['./possibledrive.component.css']
})
export class PossibledriveComponent implements OnInit {
  possibledriveForm:any
  constructor() { }

  ngOnInit(): void {
    this.possibledriveForm = new FormGroup(
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
