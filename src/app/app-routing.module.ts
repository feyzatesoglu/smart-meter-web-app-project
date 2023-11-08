import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LogInComponent } from './User/log-in/log-in.component';
import { SignUpComponent } from './User/sign-up/sign-up.component';
import { HomeComponent } from './HomePage/home/home.component';

const routes: Routes = [
  {path:'anasayfa', component: HomeComponent},
  {path:'giris-yap', component: LogInComponent},
  {path:'uye-ol', component: SignUpComponent},
  {path:'',redirectTo:'home',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
