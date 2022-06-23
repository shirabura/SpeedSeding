import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Users } from 'src/app/models/users';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  SignUpForm: any;


  constructor(private db: DbService, private router: Router) { }

  ngOnInit(): void {
    this.SignUpForm = new FormGroup(
      {
        Id: new FormControl('',[Validators.required, Validators.maxLength(9), Validators.minLength(9)]),
        FirsteName: new FormControl('', [Validators.required]),
        LastName: new FormControl('', [Validators.required]),
        Phone: new FormControl('',[Validators.required, Validators.maxLength(10), Validators.minLength(9)]),
        Password: new FormControl('',[Validators.required])

      }
    )
  }
  DoSingUp() {
    const user: Users = {
      Id: this.SignUpForm.controls.Id.value,
      FirsteName: this.SignUpForm.controls.FirsteName.value,
      LastName: this.SignUpForm.controls.LastName.value,
      Phone: this.SignUpForm.controls.Phone.value,
      Password: this.SignUpForm.controls.Password.value
    }
    console.log(user);
    this.db.DoSingUp(user).subscribe(res => {
      console.log(res)

      if (res == null)
        alert("שגיאת שרת")
      else {
        this.db.user = res
        console.log("res:"+res);
        
        alert("נוסף בהצלחה")
        this.router.navigate(['Home'])
      }
    })
  }


}
