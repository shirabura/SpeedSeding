import { tokenize } from '@angular/compiler/src/ml_parser/lexer';
import { Component, OnInit } from '@angular/core';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-view-rating',
  templateUrl: './view-rating.component.html',
  styleUrls: ['./view-rating.component.css']
})
export class ViewRatingComponent implements OnInit {

  score: number = 0

  constructor(public db: DbService) { }

  ngOnInit(): void {
    console.log(this.db.user.FirsteName);

    this.db.Viewrating().subscribe(res => {
      console.log(res)
      if (res == null)
        alert("שגיאת שרת")
      else {
        this.score = res
      }
    }

    )
  }

}
