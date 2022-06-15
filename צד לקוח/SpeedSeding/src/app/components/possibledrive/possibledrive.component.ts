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
  source?: Address;
  destianation?: Address;
  constructor(private db: DbService) { }

  ngOnInit(): void {
    this.possibledriveForm = new FormGroup(
      {
        IDOFDELIVER: new FormControl(''),
        DATE: new FormControl(''),
        HOUR: new FormControl(''),
        SOURSEADRESS: new FormControl(''),
        DESTINATIONADRESS: new FormControl(''),
  
       }
     )
  }
  handleDestinationChangeOfDESTINATIONADRESS(a: Address) {
    this.destianation = a;
    console.log(a)
  }
  handleDestinationChangeOfSOURSEADRESS(a: Address) {
    this.source = a;
    console.log(a)
  }

  handleDestinationChange(a: Address) {
    console.log(a)
  }
  EnterPossibleDrive(){
    if (this.source != undefined && this.destianation != undefined) {
    console.log(this.possibledriveForm);
    const enterpossibledrive: possibledrive = {
      IDOFDELIVER: this.possibledriveForm.controls.IDOFDELIVER.value,
      DATE: this.possibledriveForm.controls.DATE.value,
      HOUR: this.possibledriveForm.controls.HOUR.value,
      SOURSEADRESS: this.source!.formatted_address,// this.enterreqwestForm.controls.SOURSEADRESS.value,
        DESTINATIONADRESS: this.destianation!.formatted_address //this.enterreqwestForm.controls.DESTINATIONADRESS.value
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
  
       else{
       alert("נא למלא מקור ויעד!")
       }

}
}
