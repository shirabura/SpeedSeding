import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutTheCompanyComponent } from './components/about-the-company/about-the-company.component';
import { DriverComponent } from './components/driver/driver.component';
import { HelpComponent } from './components/help/help.component';
import { HomeComponent } from './components/home/home.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { SingInComponent } from './components/sing-in/sing-in.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'Home', component: HomeComponent },
  { path: 'SignIn', component: SingInComponent },
  { path: 'SignUp', component: SignUpComponent },
  { path: 'About', component: AboutTheCompanyComponent },
  { path: 'Help', component: HelpComponent },
  {path:'driver', component:DriverComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
