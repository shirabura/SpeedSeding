import { Component, OnInit } from '@angular/core';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-respons',
  templateUrl: './respons.component.html',
  styleUrls: ['./respons.component.css']
})
export class ResponsComponent implements OnInit {

  constructor(public db: DbService) { }

  ngOnInit(): void {
  }

}
