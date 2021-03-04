import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GroupDetailsComponent } from './group/group-details/group-details.component';
import { GroupListComponent } from './group/group-list/group-list.component';
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
   {
      path: 'groups/:id',
      component: GroupDetailsComponent,
   },
   {
      path: 'groups',
      component: GroupListComponent,
   },
   { path: '**', component: NotFoundComponent },
];

@NgModule({
   imports: [RouterModule.forRoot(routes)],
   exports: [RouterModule],
})
export class AppRoutingModule {}
