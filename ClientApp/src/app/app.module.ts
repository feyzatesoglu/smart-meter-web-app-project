
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
import { AdminPageComponent } from './admin-page/admin-page.component';
import { AccountService } from './Services/account.service';
<<<<<<< HEAD
import { UserProfileComponent } from './User/user-profile/user-profile.component';
=======
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
>>>>>>> 620b2dcf8ccfe6545b19dea8a11710ec21e19647

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
    UserProfileComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [AccountService],
  bootstrap: [AppComponent]
})
export class AppModule { }
