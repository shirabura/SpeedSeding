import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { possibledrive } from 'src/app/models/posibledrive';
import { Users } from 'src/app/models/users';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.css']
})
export class ResultsComponent implements OnInit {

  status: number = 0

  constructor(public db:DbService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(
      data => {
        this.status = data["status"];
      },
      err => {
        console.log("error:" + err.message);
      }
    )
  }

}
