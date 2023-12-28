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
import { LastQueriesScreenComponent } from './User/last-queries-screen/last-queries-screen.component';

const routes: Routes = [
  {path:'', component: HomeComponent},
  {path:'anasayfa', component: HomeComponent},
  {path:'giris-yap', component: LogInComponent},
  {path:'uye-ol', component: SignUpComponent},
  {path:'sorgula', component: QueryScreenComponent, canActivate: [AuthGuard]},
  {path:'anasayfa',redirectTo:'home',pathMatch:'full'},
  {path:'iletisim', component:ContactComponent},
  {path:'profil', component:UserProfileComponent},
  {path:'admin', component:AdminPageComponent},
  {path:'profil', component:UserProfileComponent},
  {path:'kullanici-ekle', component:AddUserComponent},
  {path:'gecmis-sorgular', component:LastQueriesScreenComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
