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

 

  constructor(public db:DbService) { }

  ngOnInit(): void {
    

  }

}
