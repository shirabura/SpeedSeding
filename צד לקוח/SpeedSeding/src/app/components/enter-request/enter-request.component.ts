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
        IDOFDELIVER: new FormControl(''),
        DATE: new FormControl(''),
        HOUR: new FormControl(''),
        SOURSEADRESS: new FormControl(''),
        DESTINATIONADRESS: new FormControl(''),
        
  
       }
     )
  }
  handleDestinationChange(a: Address) {
    console.log(a)
  }
  Enterreqwest(){
    console.log(this.enterreqwestForm);
    const enterreqwest: possibledrive = {
      IDOFDELIVER: this.enterreqwestForm.controls.IDOFDELIVER.value,
      DATE: this.enterreqwestForm.controls.DATE.value,
      HOUR: this.enterreqwestForm.controls.HOUR.value,
      SOURSEADRESS: this.enterreqwestForm.controls.SOURSEADRESS.value,
      DESTINATIONADRESS: this.enterreqwestForm.controls.DESTINATIONADRESS.value
    }
     console.log(enterreqwest);
     this.db.Enterreqwest(enterreqwest).subscribe(res => {
     console.log(res)

      if (res == null)
      alert("שגיאת שרת")
       else
      alert("כניסה למערכת")
  }
  )
} 
}
