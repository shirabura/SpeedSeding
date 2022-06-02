import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { singin } from '../models/sing-in';
import { Users } from '../models/users';

@Injectable({
  providedIn: 'root'
})
export class DbService {

  constructor(private httpClient:HttpClient) { }
  singin(login:singin):Observable<singin>{
    return this.httpClient.get<singin>('https://localhost:44334/api/USER/LoginUser/'+login.firstname+'/'+login.pass);
  }

  getUserDetails():Observable<Users[]>{
    return this.httpClient.get<Users[]>('https://localhost:44334/api/USER/GetallUsers');
  }

  getUserSignUp(user:Users):Observable<Users>{
    return this.httpClient.post<Users>('https://localhost:44334/api/USER/GetallUsers',user);

  }
}
