import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { possibledrive } from '../models/posibledrive';
import { singin } from '../models/sing-in';
import { Users } from '../models/users';
import { viewrating } from '../models/view-rating';

@Injectable({
  providedIn: 'root'
})
export class DbService {

  constructor(private httpClient:HttpClient) { }
  singin(login:singin):Observable<singin>{
    return this.httpClient.post<singin>('https://localhost:44334/api/USER/LoginUser/',login);
  }
  DoSingUp(user:Users):Observable<Users>{
    return this.httpClient.post<Users>('https://localhost:44334/api/USER/singup/',user);
  }
 
  EnterPossibleDrive(enterpossibledrive:possibledrive):Observable<possibledrive>{
    return this.httpClient.post<possibledrive>('https://localhost:44334/api/POSSIBLEDRIVE/enterpossibledrive',enterpossibledrive);

  }
  Enterreqwest(enterreqwest: possibledrive):Observable<possibledrive>{
    return this.httpClient.post<possibledrive>('https://localhost:44334/api/DELIVERy/enterreqwest',enterreqwest);

  }
  Viewrating(Viewrating: viewrating):Observable<viewrating>{
    return this.httpClient.post<viewrating>('https://localhost:44334/api/RATING/viewrating',Viewrating);

  }
  
  getUserDetails():Observable<Users[]>{
    return this.httpClient.get<Users[]>('https://localhost:44334/api/USER/GetallUsers');
  }

  // getUserSignUp(user:Users):Observable<Users>{
  //   return this.httpClient.post<Users>('https://localhost:44334/api/USER/GetallUsers',user);

  // }
}
