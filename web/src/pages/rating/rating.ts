import { Component } from '@angular/core';
import {FormControl} from '@angular/forms';
import { LoadingController, ModalController } from 'ionic-angular';
import 'rxjs/add/operator/debounceTime';

import { RateInfo } from '../../models/rating-response';

import { RatingService } from '../../providers/rating-service';

import { ClasscodeLookupPage} from './classcodeLookup';

@Component({
  selector: 'page-rating',
  templateUrl: 'rating.html'
})
export class RatingPage {
  rateInfo: RateInfo;
  premisesPremium: number = 0;
  productsPremium: number = 0;
  totalPremium: number = 0;
  exposure: number = null;
  selectedClasscode: number = null;
  selectedLocation: string = null;
  
  selectedClasscodeControl = new FormControl();
  selectedLocationControl = new FormControl();
  exposureControl = new FormControl();

  locationError: boolean = false;
  exposureError: boolean = false;
  
  constructor(private ratingService: RatingService, public loadingCtrl: LoadingController, public modalCtrl: ModalController) {
  }

  ngOnInit() {
    // debounce keystroke events
    this.selectedClasscodeControl
      .valueChanges
      .debounceTime(1000)
      .subscribe(newValue => {this.selectedClasscode = newValue; this.calculate()});

      this.selectedLocationControl
      .valueChanges
      .debounceTime(1000)
      .subscribe(newValue => {this.selectedLocation = newValue; this.onLocationChanged()});

      this.exposureControl
      .valueChanges
      .debounceTime(1000)
      .subscribe(newValue => {this.exposure = newValue; this.onExposureChanged()});
  }

 onLocationChanged(): void{
    var location = this.parseRawLocation(this.selectedLocation);

    if(!location)
    {
      this.locationError = true
      return;
    }

    this.calculate();
 }

 onExposureChanged(): void{
  
  if(this.exposure < 1)
  {
    this.exposureError = true;
    return;
  }

  this.calculate();
}

 calculate(): void {
  this.rateInfo = null;

  if(!this.selectedClasscode || !this.selectedLocation) return;

  var location = this.parseRawLocation(this.selectedLocation);

  let loader = this.loadingCtrl.create({content: "Calculating..."});

  loader.present().then(()=>{
    this.ratingService.getRates(location.city, location.state, location.zipcode, this.selectedClasscode).subscribe(response => {
      if(response.apiResult.successResult){
        this.rateInfo = response.glCoverage.classCodeSchedule[0].classCodeRateInfo.rateInfo;
        this.calculatePremium();
      }

      loader.dismiss();
    });
  });
 }

 calculatePremium(): void {
    if(this.exposure == null) return;

  
    if(this.rateInfo.rates.premisesRate)
    {
      this.premisesPremium = 
        this.rateInfo.rates.premisesRate * 
        this.exposure /
        this.rateInfo.exposure.exposureDivisor;
    }

    if(this.rateInfo.rates.productsRate)
    {
      this.productsPremium = 
        this.rateInfo.rates.productsRate * 
        this.exposure / 
        this.rateInfo.exposure.exposureDivisor;
    }

    this.totalPremium = this.premisesPremium + this.productsPremium;
  }

  parseRawLocation(rawLocation: string): any {
    var location: any = {}

    var validLoc = rawLocation.trim().match(/^[\s]*\d{5}[\s]*$|^[\s]*[A-Za-z\s]+[,\s][\s]*[A-Za-z]{2,}[\s]*$/g);
    if (!validLoc || validLoc.length === 0) {
        location = null;
    }
    else {
        var locDetails = validLoc[0].split(',');
        if (locDetails.length === 1) {
            location.city = "";
            location.state = "";
            location.zipcode = locDetails[0].trim();
        } else { 
            location.city = (locDetails[0].charAt(0).toUpperCase() + locDetails[0].slice(1)).trim();
            location.state = locDetails[1].trim();
            location.zipcode = "";
        }
    }

    return location;
  }

  selectClasscode() {
    let modal = this.modalCtrl.create(ClasscodeLookupPage, null);
    
    modal.onDidDismiss(data => {
      if (data) {
        this.selectedClasscode = data.classcode;
        console.log(data.label);
      }
    });

    modal.present();
  }
}