import { Component, ViewChild } from '@angular/core';

import { Platform, Nav } from 'ionic-angular';

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
    public authService: AuthService
  ) {
    this.initializeApp();
  }

  initializeApp() {
    this.platform.ready().then(() => {
      this.authService.hasValidToken().then((response)=>{
        this.nav.setRoot(RatingPage);
      }).catch(e=>
        this.nav.setRoot(LoginPage)
      );
    });
  }
}
