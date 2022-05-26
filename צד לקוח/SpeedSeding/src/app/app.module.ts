import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SingInComponent } from './components/sing-in/sing-in.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UserComponent } from './components/user/user.component';
import { NavComponent } from './components/nav/nav.component';
import { HomeComponent } from './components/home/home.component';
import { DriverComponent } from './components/driver/driver.component'
import { AboutTheCompanyComponent } from './components/about-the-company/about-the-company.component'
import { ResponsComponent } from './components/respons/respons.component'
import { EnterRequestComponent } from './components/enter-request/enter-request.component'
import { HistoryComponent } from './components/history/history.component'
import { PossibledriveComponent } from './components/possibledrive/possibledrive.component'
import { HelpComponent } from './components/help/help.component'
import { ViewRatingComponent } from './components/view-rating/view-rating.component'
import { GooglePlaceModule } from 'ngx-google-places-autocomplete';
import { ngxLoadingAnimationTypes, NgxLoadingModule } from 'ngx-loading';
import { ResultsComponent } from './components/results/results.component';

@NgModule({
  declarations: [
    AppComponent,
    SingInComponent,
    SignUpComponent,
    UserComponent,
    NavComponent,
    HomeComponent,
    DriverComponent,
    AboutTheCompanyComponent,
    HelpComponent,
    PossibledriveComponent,
    HistoryComponent,
    ViewRatingComponent,
    EnterRequestComponent,
    ResponsComponent,
    ResultsComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
