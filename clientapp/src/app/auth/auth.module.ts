import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AuthRoutingModule } from './auth-routing.module';
import { MaterialModule } from '../material/material.module';

import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

@NgModule({
    declarations: [
        LoginComponent,
        RegisterComponent,
    ],
    imports: [
        CommonModule,
        AuthRoutingModule,
        MaterialModule,
    ],
})
export class AuthModule {}
