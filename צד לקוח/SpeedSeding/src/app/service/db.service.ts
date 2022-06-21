import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { deliver } from '../models/deliver';
import { possibledrive } from '../models/posibledrive';
import { singin } from '../models/sing-in';
import { Users } from '../models/users';

@Injectable({
  providedIn: 'root'
})
export class DbService {

  user: Users = new Users()
  history: Array<deliver> = new Array<deliver>()
  result: Users = new Users()
  results: Array<Users> = new Array<Users>()

  constructor(private httpClient: HttpClient) { }
  singin(login: singin): Observable<Users> {
    return this.httpClient.post<Users>('https://localhost:44334/api/USER/LoginUser/', login);
  }
  DoSingUp(user: Users): Observable<Users> {
    console.log("user:" + user);

    return this.httpClient.post<Users>('https://localhost:44334/api/USER/singup/', user);
  }

  EnterPossibleDrive(enterpossibledrive: possibledrive): Observable<Users> {
    return this.httpClient.post<Users>('https://localhost:44334/api/POSSIBLEDRIVE/enterpossibledrive', enterpossibledrive);

  }
  Enterreqwest(enterreqwest: possibledrive): Observable<Array<Users>> {
    return this.httpClient.post<Array<Users>>('https://localhost:44334/api/DELIVERy/enterreqwest', enterreqwest);

  }
  Viewrating(): Observable<number> {
    return this.httpClient.post<number>('https://localhost:44334/api/RATING/viewrating', this.user.Id);
  }

  getUserDetails(): Observable<Users[]> {
    return this.httpClient.get<Users[]>('https://localhost:44334/api/USER/GetallUsers');
  }
  viewhistory(): Observable<deliver> {
    return this.httpClient.post<deliver>('https://localhost:44334/api/POSSIBLEDRIVE/viewhistory', this.user.Id);

  }
  // getUserSignUp(user:Users):Observable<Users>{
  //   return this.httpClient.post<Users>('https://localhost:44334/api/USER/GetallUsers',user);

  // }
}
