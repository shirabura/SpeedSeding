import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Address } from 'ngx-google-places-autocomplete/objects/address';
import { possibledrive } from 'src/app/models/posibledrive';
import { DbService } from 'src/app/service/db.service';


@Component({
  selector: 'app-possibledrive',
  templateUrl: './possibledrive.component.html',
  styleUrls: ['./possibledrive.component.css']
})
export class PossibledriveComponent implements OnInit {
  possibledriveForm:any
  constructor(private db: DbService) { }

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
  EnterPossibleDrive(){
    console.log(this.possibledriveForm);
    const enterpossibledrive: possibledrive = {
      tz: this.possibledriveForm.controls.tz.value,
      date: this.possibledriveForm.controls.date.value,
      hour: this.possibledriveForm.controls.hour.value,
      sourceadress: this.possibledriveForm.controls.sourceadress.value,
      destinationadress: this.possibledriveForm.controls.destinationadress.value
    }
    console.log(enterpossibledrive);
    this.db.EnterPossibleDrive(enterpossibledrive).subscribe(res => {
      console.log(res)
debugger
      if (res == null)
        alert("שגיאת שרת")
      else
        alert("כניסה למערכת")
    }
    )
  }

}
