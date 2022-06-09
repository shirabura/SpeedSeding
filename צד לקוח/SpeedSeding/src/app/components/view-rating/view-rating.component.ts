import { tokenize } from '@angular/compiler/src/ml_parser/lexer';
import { Component, OnInit } from '@angular/core';
import { viewrating } from 'src/app/models/view-rating';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-view-rating',
  templateUrl: './view-rating.component.html',
  styleUrls: ['./view-rating.component.css']
})
export class ViewRatingComponent implements OnInit {

  constructor(private db: DbService) { }
    tz:any;
  ngOnInit(): void {
    
  }
  Viewrating() {

   
    const Viewrating: viewrating = {
      tz:this.tz.value
    }

    console.log(Viewrating);
    this.db.Viewrating(Viewrating).subscribe(res => {
      console.log(res)
debugger
      if (res == null)
        alert("שגיאת שרת")
      else
        alert(res)
    }
   
    )
  }

}
