import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class APIService {  
  constructor(public http: Http) { }

  makeAPICall(url): Observable<any> {
    let token = localStorage.getItem('token');
    let headers = new Headers();
    headers.append("Content-Type", "application/json; charset=utf-8");
    headers.append("Authorization", "Bearer " + token);
    let opts = new RequestOptions();
    opts.headers = headers;

    return this.http.get(url, opts);
  } 
}