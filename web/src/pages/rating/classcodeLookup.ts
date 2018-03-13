import { Component } from '@angular/core';
import { ViewController, LoadingController, AlertController } from 'ionic-angular';

import { RatingService } from '../../providers/rating-service';
import { Classcode } from '../../models/classcode';


@Component({
  selector: 'page-classcodeLookup',
  templateUrl: 'classcodeLookup.html'
})
export class ClasscodeLookupPage {  

  searchQuery: string = '';
  classcodes: Classcode[]
  origClasscodes: Classcode[]
  
  constructor(private ratingService: RatingService, private view: ViewController, public loadingCtrl: LoadingController, public alertCtrl: AlertController) {
    this.initializeItems();
  }


  ionViewDidLoad() {
      console.log("Lookup Loaded")
  }

  closeModal(){
    this.view.dismiss();
  }

  initializeItems() {
    if(this.origClasscodes && this.origClasscodes.length > 0 ) return;

    let loader = this.loadingCtrl.create({content: "Please wait..."});

    loader.present().then(()=>{
      this.ratingService.loadClasscodes().subscribe(response => {
          this.origClasscodes = response;
          loader.dismiss();
      }, error => {
              this.errorAlert('Failed to retrieve classcodes');
              loader.dismiss();
      });
    });
  }

  filterClasscodes(ev: any) {
    // set val to the value of the searchbar
    let val = ev.target.value;

    // if the value is an empty string don't filter the items
    if (val && val.length > 1) {
      this.classcodes = this.origClasscodes.filter((item) => {
        return (item.label.toLowerCase().indexOf(val.toLowerCase()) > -1);
      })
    }
    else
      this.classcodes = null;
  }

  selected(ev: any, classcode: Classcode) {
    this.view.dismiss(classcode);
  }

  private errorAlert(message: string): void{
    let alert = this.alertCtrl.create({
      subTitle:message ,
      buttons:['OK']
    });
    alert.present();
  }
}