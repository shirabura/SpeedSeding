import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  deliver: boolean = false;
  about:boolean=false;
  customer:boolean=false;

  constructor() { }

  ngOnInit(): void {
  }
  changedeliver() {
    this.deliver = !this.deliver;
    this.about=false;
    this.customer=false
    console.log("deliver:" + this.deliver);

  }
  changeabout(){
    this.deliver = false;
    this.about=!this.about;
    this.customer=false

  }
  changecustomer(){
    this.deliver = false;
    this.about=false;
    this.customer=!this.customer;

  }
}
