import { Injectable } from '@angular/core';
import {Driver} from '../models/driver';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class DriverService {
  constructor(private http: HttpClient) { }

  // public getDriver():Observable<Driver[]>{
  //   return this.http.get<Driver[]>(`${environment.apiUrl}/${this.url}`);
  // }
  public getDriver():Observable<Driver[]>{
    return this.http.get<Driver[]>(`${environment.apiUrl}`);
  }
}
