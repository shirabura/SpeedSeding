import { Component, Input, OnInit } from '@angular/core';
import { Rating } from 'src/app/models/rating';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-respons',
  templateUrl: './respons.component.html',
  styleUrls: ['./respons.component.css']
})
export class ResponsComponent implements OnInit {

  rating: Rating = new Rating()

  constructor(public db: DbService) { }

  ngOnInit(): void {

  }
  EnterRespons() {
    console.log("rating:" + this.rating.DELIVERYID);
    
  }
}
