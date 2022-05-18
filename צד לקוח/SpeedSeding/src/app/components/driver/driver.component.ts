import { Component, OnInit } from '@angular/core';
import { Address } from 'ngx-google-places-autocomplete/objects/address';

@Component({
  selector: 'app-driver',
  templateUrl: './driver.component.html',
  styleUrls: ['./driver.component.css']
})
export class DriverComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  myAddress: Address = new Address();
  handleDestinationChange(a: Address) {
    console.log(a)
    this.myAddress = a;
  }


}
