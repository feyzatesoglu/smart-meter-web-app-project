import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LogInComponent } from './User/log-in/log-in.component';
import { SignUpComponent } from './User/sign-up/sign-up.component';
import { HomeComponent } from './HomePage/home/home.component';
import { QueryScreenComponent } from './User/query-screen/query-screen.component';
import { ContactComponent } from './User/contact/contact.component';
import { AuthGuard } from './User/log-in/login.guard';
import { UserProfileComponent } from './User/user-profile/user-profile.component';
import { AdminPageComponent } from './Admin/admin-page/admin-page.component';
import { AddUserComponent } from './Admin/add-user/add-user.component';
import { EditUserComponent } from './Admin/edit-user/edit-user.component';
import { LastQueriesScreenComponent } from './User/last-queries-screen/last-queries-screen.component';
import { ChangePasswordComponent } from './User/change-password/change-password.component';
import { ForgetPasswordComponent } from './User/forget-password/forget-password.component';
import { LanComponent } from './User/result-page/result-pages/lan/lan.component';

import { WanComponent } from './User/result-page/result-pages/wan/wan.component';
import { LpwanComponent } from './User/result-page/result-pages/lpwan/lpwan.component';
import { SatelliteComponent } from './User/result-page/result-pages/satellite/satellite.component';

const routes: Routes = [
  {path:'', component: HomeComponent},
  {path:'anasayfa', component: HomeComponent},
  {path:'giris-yap', component: LogInComponent},
  {path:'uye-ol', component: SignUpComponent},
  {path:'sorgula', component: QueryScreenComponent}, //canActivate: [AuthGuard]
  {path:'anasayfa',redirectTo:'home',pathMatch:'full'},
  {path:'iletisim', component:ContactComponent},
  {path:'profil', component:UserProfileComponent},
  {path:'admin', component:AdminPageComponent},
  {path:'profil', component:UserProfileComponent},
  {path:'kullanici-ekle', component:AddUserComponent},
  {path:'kullanici-duzenle/:id', component:EditUserComponent},
  {path:'gecmis-sorgular', component:LastQueriesScreenComponent},
  {path:'sifre-degistir', component:ChangePasswordComponent},
  {path:'sifremi-unuttum', component:ForgetPasswordComponent},
  {path:'sonuc/lan', component:LanComponent},
  {path:'sonuc/wan', component:WanComponent},
  {path:'sonuc/lpwan', component:LpwanComponent},
  {path:'sonuc/satellite', component:SatelliteComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
