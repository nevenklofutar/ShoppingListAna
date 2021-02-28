import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '../app/material/material.module';
import { NavToolbarComponent } from './shared/components/nav-toolbar/nav-toolbar.component';
import { HomeComponent } from './home.component';
import { NotFoundComponent } from './not-found.component';

@NgModule({
   declarations: [AppComponent, NavToolbarComponent, HomeComponent, NotFoundComponent],
   imports: [BrowserModule, AppRoutingModule, BrowserAnimationsModule, MaterialModule,],
   providers: [],
   bootstrap: [AppComponent],
})
export class AppModule {}
