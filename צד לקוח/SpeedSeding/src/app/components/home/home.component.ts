import { Component, OnInit } from '@angular/core';
import { Address } from 'ngx-google-places-autocomplete/objects/address';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  home = "assets/11.png"

  constructor() { }

  ngOnInit(): void {
  }

  // כשהכתובת משתנה
  handleDestinationChange(a: Address) {
    console.log(a)
  }

}
