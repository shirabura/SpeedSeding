import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Users } from '../models/users';

@Injectable({
  providedIn: 'root'
})
export class DbService {

  constructor(private httpClient:HttpClient) { }

  getUserDetails():Observable<Users[]>{
    return this.httpClient.get<Users[]>('http://localhost:51067/api/USERS/GetallUsers');
  }

  getUserSignUp(){

  }
}
