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
  changetottrue() {
    this.deliver = !this.deliver;
    this.about=false;
    this.customer=false
    console.log("deliver:" + this.deliver);

  }
}
