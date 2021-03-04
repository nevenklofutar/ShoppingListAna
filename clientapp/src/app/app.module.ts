import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '../app/material/material.module';
import { NavToolbarComponent } from './shared/components/nav-toolbar/nav-toolbar.component';
import { HomeComponent } from './home.component';
import { NotFoundComponent } from './not-found.component';
import { GroupListComponent } from './group/group-list/group-list.component';
import { GroupListItemComponent } from './group/group-list-item/group-list-item.component';
import { GroupDetailsComponent } from './group/group-details/group-details.component';
import { BaseComponent } from './shared/components/base/base.component';

@NgModule({
   declarations: [AppComponent, NavToolbarComponent, HomeComponent, NotFoundComponent, GroupListComponent, GroupListItemComponent, GroupDetailsComponent, BaseComponent],
   imports: [BrowserModule, HttpClientModule, AppRoutingModule, BrowserAnimationsModule, MaterialModule,],
   providers: [],
   bootstrap: [AppComponent],
})
export class AppModule {}
