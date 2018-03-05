import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { APIService } from './api-service';

@Injectable()
export class AuthService {
  loginUrl: string = 'http://sramaling10/BAQuickRaterAPI/api/token';
  validateUrl: string = 'http://sramaling10/BAQuickRaterAPI/api/validate';
  
  constructor(public http: Http, private apiService: APIService) {  }

  login(username: string, password: string) : Promise<void> {
    let promise = new Promise<void>((resolve, reject) => {
      var data = "grant_type=password&username=" + username + "&password=" + password;
      this.http.post(this.loginUrl, data).toPromise().then((response) => {
          if(response.status == 200)
          {
            var token = response.json().access_token;
            resolve();
            localStorage.setItem('token', token);
          }
          else
            reject();
      },
      (error) => { reject(false); });
    });

    return promise;
  }

  hasValidToken() : Promise<void> {
    return this.apiService.makeAPICall(this.validateUrl).toPromise();
  }
}