import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { RatingPage } from './rating';
import { ClasscodeLookupPage} from './classcodeLookup';

@NgModule({
  declarations: [
    RatingPage,
    ClasscodeLookupPage
  ],
  imports: [
    IonicPageModule.forChild(RatingPage),
    IonicPageModule.forChild(ClasscodeLookupPage)
  ],
})
export class RatingPageModule {}
