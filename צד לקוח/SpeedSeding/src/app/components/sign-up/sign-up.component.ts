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
        Id: new FormControl(''),
        FirsteName: new FormControl(''),
        LastName: new FormControl(''),
        Phone: new FormControl(''),
        Password: new FormControl('')
  
       }
     )
   }
   DoSingUp(){
    const user:Users={
      Id:this.SignUpForm.controls.Id.value, 
      FirsteName:this.SignUpForm.controls.FirsteName.value,
      LastName:this.SignUpForm.controls.LastName.value,
      Phone:this.SignUpForm.controls.Phone.value,
      Password:this.SignUpForm.controls.Password.value
    }
    console.log(user);
    this.db.DoSingUp(user).subscribe(res => {
      console.log(res)

      if (res == null)
        alert("שגיאת שרת")
      else
        alert("נוסף בהצלחה")
    })
  }
  

}
