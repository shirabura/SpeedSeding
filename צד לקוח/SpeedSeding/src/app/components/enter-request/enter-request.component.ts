import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Address } from 'ngx-google-places-autocomplete/objects/address';
import { possibledrive } from 'src/app/models/posibledrive';
import { DbService } from 'src/app/service/db.service';


@Component({
  selector: 'app-enter-request',
  templateUrl: './enter-request.component.html',
  styleUrls: ['./enter-request.component.css']
})
export class EnterRequestComponent implements OnInit {
  enterreqwestForm: any
  source?: Address;
  destianation?: Address;
  constructor(private db: DbService, private router: Router) { }

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
  handleDestinationChangeOfDESTINATIONADRESS(a: Address) {
    this.destianation = a;
    console.log(a)
  }
  handleDestinationChangeOfSOURSEADRESS(a: Address) {
    this.source = a;
    console.log(a)
  }


  Enterreqwest() {

    if (this.source != undefined && this.destianation != undefined) {
      console.log(this.enterreqwestForm);
      const enterreqwest: possibledrive = {
        IDOFDELIVER: this.enterreqwestForm.controls.IDOFDELIVER.value,
        DATE: this.enterreqwestForm.controls.DATE.value,
        HOUR: this.enterreqwestForm.controls.HOUR.value,
        SOURSEADRESS: this.source!.formatted_address,// this.enterreqwestForm.controls.SOURSEADRESS.value,
        DESTINATIONADRESS: this.destianation!.formatted_address //this.enterreqwestForm.controls.DESTINATIONADRESS.value
      }
      console.log(enterreqwest);
      this.db.Enterreqwest(enterreqwest).subscribe(res => {
        console.log(res)

        if (res == null)
          alert("שגיאת שרת")
        else {
          // this.db.result = res;
          this.router.navigate(["Result/1"])
        }
      }

      )
    }
    else {
      alert("נא למלא מקור ויעד!")
    }
  }


}

