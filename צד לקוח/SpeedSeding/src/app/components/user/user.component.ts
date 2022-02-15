import { Component, OnInit } from '@angular/core';
import { Users } from 'src/app/models/users';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {


  users: Users[] = [  ];
  


 

  constructor(private db:DbService) { }

  ngOnInit(): void {

      this.db.getUserDetails().subscribe((res)=>{
              console.log(res);
              this.users = res;
      })
  }

}
