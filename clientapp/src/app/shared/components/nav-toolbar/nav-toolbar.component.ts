import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
   selector: 'app-nav-toolbar',
   templateUrl: './nav-toolbar.component.html',
   styleUrls: ['./nav-toolbar.component.css'],
})
export class NavToolbarComponent implements OnInit {
   constructor(private router: Router) {}

   ngOnInit(): void {}

   navRedirect(link: string) {
      this.router.navigate([link]);
   }
}
