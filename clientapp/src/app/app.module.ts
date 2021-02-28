import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '../app/material/material.module';
import { NavToolbarComponent } from './shared/components/nav-toolbar/nav-toolbar.component';

@NgModule({
   declarations: [AppComponent, NavToolbarComponent],
   imports: [BrowserModule, AppRoutingModule, BrowserAnimationsModule, MaterialModule,],
   providers: [],
   bootstrap: [AppComponent],
})
export class AppModule {}
