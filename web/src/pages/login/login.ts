import { Component } from '@angular/core';
import 'rxjs/add/operator/debounceTime';
import { NavController, AlertController, LoadingController } from 'ionic-angular';

import { AuthService } from '../../providers/auth-service';
import { RatingPage } from '../rating/rating';

@Component({
  selector: 'page-login',
  templateUrl: 'login.html'
})
export class LoginPage {
  username: string = null;
  password: string = null;
    
  constructor(public authService: AuthService, public navCtrl: NavController, public alertCtrl: AlertController, public loadingCtrl: LoadingController) {
  }

  login(): void {
    if (this.username === null || this.password === null) {
      this.loginErrorAlert('Username/Password required');
      return;
    }

    let loader = this.loadingCtrl.create({content: "Please wait..."});

    loader.present().then(() => {
      this.authService.login(this.username, this.password).then(response => {
        this.navCtrl.setRoot(RatingPage);
        loader.dismiss();
      }, error => {
        this.loginErrorAlert('Login failed');
        loader.dismiss();
      });
    });
  }

  private loginErrorAlert(message: string): void{
    let alert = this.alertCtrl.create({
      subTitle:message ,
      buttons:['OK']
    });
    alert.present();
  }
}