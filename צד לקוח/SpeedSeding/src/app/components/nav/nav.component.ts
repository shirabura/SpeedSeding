import { Component, OnInit } from '@angular/core';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  deliver: boolean = false;
  about: boolean = false;
  customer: boolean = false;

  home = "assets/11.png"

  constructor(public db: DbService) { }

  ngOnInit(): void {
  }

  changeabout() {
    this.deliver = false;
    this.about = !this.about;
    this.customer = false
    console.log("about:" + this.about);
  }
  changedeliver() {
    if (this.db.user.Id == null) {
      alert("אופססס😞 אינך מחובר למערכת!!!")
    }
    else {
      this.deliver = !this.deliver;
      this.about = false;
      this.customer = false
      console.log("deliver:" + this.deliver);
    }
  }

  changecustomer() {
    if (this.db.user.Id == null) {
      alert("אופססס😞 אינך מחובר למערכת!!!")
    }
    else {
      this.deliver = false;
      this.about = false;
      this.customer = !this.customer;
    }
  }
}
