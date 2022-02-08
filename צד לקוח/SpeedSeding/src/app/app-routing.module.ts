import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { SingInComponent } from './components/sing-in/sing-in.component';


const routes: Routes = [
  { path: 'up', component: SignUpComponent },
  { path: 'sign-up', redirectTo: 'up' },
  { path: 'in', component: SingInComponent },
  { path: 'sign-in', redirectTo: 'in' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
