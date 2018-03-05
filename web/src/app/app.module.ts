import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { IonicApp, IonicModule, IonicErrorHandler } from 'ionic-angular';
import { NativeStorage } from '@ionic-native/native-storage';
import { MyApp } from './app.component';
import { HttpModule } from '@angular/http';

import { LoginPage } from '../pages/login/login';
import { RatingPage } from '../pages/rating/rating';

import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { RatingService } from '../providers/rating-service';
import { AuthService } from '../providers/auth-service';
import { APIService } from '../providers/api-service';

@NgModule({
  declarations: [
    MyApp,
    RatingPage,
    LoginPage
  ],
  imports: [
    BrowserModule,
    HttpModule,
    IonicModule.forRoot(MyApp),
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    RatingPage,
    LoginPage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    {provide: ErrorHandler, useClass: IonicErrorHandler},
    RatingService,
    AuthService,
    APIService,
    NativeStorage
  ]
})
export class AppModule {}
