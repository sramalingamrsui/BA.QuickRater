import { Component, ViewChild } from '@angular/core';

import { Platform, Nav, LoadingController } from 'ionic-angular';

import { LoginPage } from '../pages/login/login';
import { RatingPage } from '../pages/rating/rating';
import { AuthService } from '../providers/auth-service';

@Component({
  templateUrl: 'app.html'
})
export class MyApp {
  @ViewChild(Nav) nav: Nav;

  constructor(
    public platform: Platform,
    public authService: AuthService,
    public loadingCtrl: LoadingController 
  ) {
    this.initializeApp();
  }

  initializeApp() {
    let loader = this.loadingCtrl.create({content: "Please wait..."});
    
    loader.present().then(() => {
      this.platform.ready().then(() => {
        this.authService.hasValidToken().then((response)=>{
          loader.dismiss();
          this.nav.setRoot(RatingPage);
        }).catch(e=> {
          loader.dismiss();
          this.nav.setRoot(LoginPage)
        });
      });
    });
  }
}
