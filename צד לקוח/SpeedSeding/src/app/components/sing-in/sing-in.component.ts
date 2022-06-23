import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { singin } from 'src/app/models/sing-in';
import { DbService } from 'src/app/service/db.service';


@Component({
  selector: 'app-sing-in',
  templateUrl: './sing-in.component.html',
  styleUrls: ['./sing-in.component.css']
})
export class SingInComponent implements OnInit {
  SignInForm: any;

  constructor(private db: DbService, private router: Router) { }

  ngOnInit(): void {
    this.SignInForm = new FormGroup(
      {
        id: new FormControl('', [Validators.required, Validators.maxLength(9), Validators.minLength(9)]),
        pass: new FormControl('', [Validators.required])
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
        alert("מצטערים, אך אחד או יותר מהנתונים שהכנסת שגויים, נסה שנית")
      else {
        this.db.user = res
        alert("כניסה למערכת")
        this.router.navigate(['Home'])
      }
    }

    )
  }

}


