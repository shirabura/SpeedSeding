import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { singin } from 'src/app/models/sing-in';
import { DbService } from 'src/app/service/db.service';


@Component({
  selector: 'app-sing-in',
  templateUrl: './sing-in.component.html',
  styleUrls: ['./sing-in.component.css']
})
export class SingInComponent implements OnInit {
  SignInForm:any;

  constructor(private db: DbService) { }

  ngOnInit(): void {
     this.SignInForm = new FormGroup(
       {
         id: new FormControl(''),
         pass: new FormControl('')
       }
     )
  }

  doSingin() {

    console.log(this.SignInForm);
    const login: singin = {
      id: this.SignInForm.controls.id.value,
      pass: this.SignInForm.controls.pass.value
    }

    console.log(login);
    this.db.singin(login).subscribe(res => {
      console.log(res)

      if (res == null)
        alert("שגיאת שרת")
      else if(res.id==0)
        alert("מצטערים, אך אחד או יותר מהנתונים שהכנסת שגויים ,נסה שנית")
      else if(res.pass==null)
        alert("מצטערים, אך אחד או יותר מהנתונים שהכנסת שגויים ,נסה שנית")
      
      else
        alert("כניסה למערכת")
    }
   
    )
  }

}


