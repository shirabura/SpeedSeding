import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Users } from 'src/app/models/users';

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
  DoSingUp(){
   const user:Users={

    id:this.SignUpForm.controls.id.value, 
    FirsteName:this.SignUpForm.controls.firstname.value,
    LastName:this.SignUpForm.controls.LastName.value,
    Status:this.SignUpForm.controls.Status.value,
    phone:this.SignUpForm.controls.phone.value,
    Password:this.SignUpForm.controls.Password.value,

   }
   console.log(user);

  }

}
