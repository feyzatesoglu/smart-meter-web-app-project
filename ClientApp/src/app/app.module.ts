
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LogInComponent } from './User/log-in/log-in.component';
import { SignUpComponent } from './User/sign-up/sign-up.component';
import { HomeComponent } from './HomePage/home/home.component';
import { NavMenuComponent } from './NavMenu/nav-menu/nav-menu.component';
import { QueryScreenComponent } from './User/query-screen/query-screen.component';
import { ContactComponent } from './User/contact/contact.component';
import { RegistrationFormComponent } from './User/registration-form/registration-form.component';
import { AdminPageComponent } from './Admin/admin-page/admin-page.component';
import { AccountService } from './Services/account.service';
import { UserProfileComponent } from './User/user-profile/user-profile.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AddUserComponent } from './Admin/add-user/add-user.component';
import { EditUserComponent } from './Admin/edit-user/edit-user.component';
import { ChangePasswordComponent } from './User/change-password/change-password.component';
import { ForgetPasswordComponent } from './User/forget-password/forget-password.component';
import { QueryService } from './Services/query.service';
import { LanComponent } from './User/result-page/result-pages/lan/lan.component';
import { WanComponent } from './User/result-page/result-pages/wan/wan.component';
import { LpwanComponent } from './User/result-page/result-pages/lpwan/lpwan.component';
import { SatelliteComponent } from './User/result-page/result-pages/satellite/satellite.component';
import { ShowFormService } from './Services/show-form.service';
import { UserTypeService } from './Services/userType.service';
import { LastQueriesScreenComponent } from './User/last-queries-screen/last-queries-screen.component';
import { UserHomepageComponent } from './User/user-homepage/user-homepage.component';



@NgModule({
  declarations: [
    AppComponent,
    LogInComponent,
    SignUpComponent,
    HomeComponent,
    NavMenuComponent,
    QueryScreenComponent,
    ContactComponent,
    RegistrationFormComponent,
    AdminPageComponent,
    UserProfileComponent,
    AddUserComponent,
    EditUserComponent,
    ChangePasswordComponent,
    ForgetPasswordComponent,
    LanComponent,
    WanComponent,
    LpwanComponent,
    SatelliteComponent,
    LastQueriesScreenComponent,
    UserHomepageComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
    
  ],
  providers: [AccountService,QueryService,ShowFormService,UserTypeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
