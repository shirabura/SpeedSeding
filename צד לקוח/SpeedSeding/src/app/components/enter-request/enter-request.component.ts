import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
 import { Address } from 'ngx-google-places-autocomplete/objects/address';
import { possibledrive } from 'src/app/models/posibledrive';
import { DbService } from 'src/app/service/db.service';


@Component({
  selector: 'app-enter-request',
  templateUrl: './enter-request.component.html',
  styleUrls: ['./enter-request.component.css']
})
export class EnterRequestComponent implements OnInit {
enterreqwestForm:any
  constructor(private db: DbService) { }

  ngOnInit(): void {
    this.enterreqwestForm = new FormGroup(
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
  Enterreqwest(){
    console.log(this.enterreqwestForm);
    const enterreqwest: possibledrive = {
      tz: this.enterreqwestForm.controls.tz.value,
      date: this.enterreqwestForm.controls.date.value,
      hour: this.enterreqwestForm.controls.hour.value,
      sourceadress: this.enterreqwestForm.controls.sourceadress.value,
      destinationadress: this.enterreqwestForm.controls.destinationadress.value
    }
     console.log(enterreqwest);
     this.db.EnterPossibleDrive(enterreqwest).subscribe(res => {
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
