import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';
import { NotFoundComponent } from './not-found.component';

const routes: Routes = [
   {
      path: '',
      component: HomeComponent,
   },
   {
      path: 'auth',
      loadChildren: () =>
         import('./auth/auth.module').then((m) => m.AuthModule),
   },
   { path: '**', component: NotFoundComponent },
];

@NgModule({
   imports: [RouterModule.forRoot(routes)],
   exports: [RouterModule],
})
export class AppRoutingModule {}
