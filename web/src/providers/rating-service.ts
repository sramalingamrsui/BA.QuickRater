import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

import { Classcode } from '../models/classcode';
import { RatingResponse } from '../models/rating-response';
import { APIService } from './api-service';

@Injectable()
export class RatingService {
  ratingApiUrl = 'https://baratingstage.rsui.com/BAQuickRaterapi/';
  
  constructor(private apiService: APIService) { }

  loadClasscodes(): Observable<Classcode[]> {
    return this.apiService.makeAPICall(`${this.ratingApiUrl}/api/ClasscodeLookup`).map(res => <Classcode[]>res.json());
  } 

  getRates(city: string, state:string, zipcode:string, classcode:number): Observable<RatingResponse> {
    var request = "city=" + city + "&state=" + state + "&zipcode=" + zipcode + "&classcode=" + classcode + "&subcode=0";
    return this.apiService.makeAPICall(`${this.ratingApiUrl}/api/RateInfoRequest?${request}`).map(res => <RatingResponse>res.json());
  } 
}