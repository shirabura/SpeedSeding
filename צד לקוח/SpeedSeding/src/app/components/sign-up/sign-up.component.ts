import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  SignUpForm:any;


  constructor() { }

  ngOnInit(): void {
    this.SignUpForm = new FormGroup(
      {
        tz: new FormControl(''),
        firstname: new FormControl(''),
        lastname: new FormControl(''),
        status: new FormControl(''),
        phone: new FormControl(''),
        pass: new FormControl('')
  
      }
    )
  }

}
