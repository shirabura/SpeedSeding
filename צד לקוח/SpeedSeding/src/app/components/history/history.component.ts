import { Component, OnInit } from '@angular/core';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {
  // history:Array<deliver>=new Array<deliver>()

  constructor(public db: DbService) { }

  ngOnInit(): void {
    console.log(this.db.user.FirsteName);

    this.db.viewhistory().subscribe(res => {
      console.log(res)
      if (res == null)
        alert("שגיאת שרת")
      else {
        // history = res
      }
    })

  }


}
