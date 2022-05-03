import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Users } from 'src/app/models/users';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  SignUpForm:any;


  constructor(private db: DbService) { }

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
     id:this.SignUpForm.controls.tz.value, 
     FirsteName:this.SignUpForm.controls.firstname.value,
     LastName:this.SignUpForm.controls.lastname.value,
     Status:this.SignUpForm.controls.status.value,
     phone:this.SignUpForm.controls.phone.value,
     Password:this.SignUpForm.controls.pass.value
    }
    console.log(user);
    this.db.getUserSignUp(user).subscribe(res => {
      console.log(res)

      if (res == null)
        alert("שגיאת שרת")
      else
        alert("נוסף בהצלחה")
    })
  }
  

}
