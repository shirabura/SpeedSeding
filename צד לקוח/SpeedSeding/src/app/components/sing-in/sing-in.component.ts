import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-sing-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sing-in.component.css']
})
export class SingInComponent implements OnInit {
  SignInForm:any;

  constructor() { }

  ngOnInit(): void {
     this.SignInForm = new FormGroup(
       {
         firstname: new FormControl(''),
         pass: new FormControl('')
       }
     )
  }

}
