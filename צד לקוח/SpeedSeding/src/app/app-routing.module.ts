import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutTheCompanyComponent } from './components/about-the-company/about-the-company.component';
import { DriverComponent } from './components/driver/driver.component';
import { HelpComponent } from './components/help/help.component';
import { HomeComponent } from './components/home/home.component';
import { PossibledriveComponent } from './components/possibledrive/possibledrive.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { SingInComponent } from './components/sing-in/sing-in.component';
import { EnterRequestComponent } from './components/enter-request/enter-request.component';
import { ResultsComponent } from './components/results/results.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'Home', component: HomeComponent },
  { path: 'SignIn', component: SingInComponent },
  { path: 'SignUp', component: SignUpComponent },
  { path: 'About', component: AboutTheCompanyComponent },
  { path: 'Help', component: HelpComponent },
  {path:'driver', component:DriverComponent},
  {path:'possibledrive', component:PossibledriveComponent},
  {path:'enterreqwest', component:EnterRequestComponent},
  {path:'Results', component:ResultsComponent},
 

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
