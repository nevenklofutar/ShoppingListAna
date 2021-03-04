import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

@Component({
   selector: 'app-base',
   templateUrl: './base.component.html',
   styleUrls: ['./base.component.css'],
})
export class BaseComponent implements OnInit, OnDestroy {
   subscriptions: Subscription[] = [];

   constructor() {}

   ngOnInit(): void {}

   ngOnDestroy(): void {
      this.subscriptions.forEach(subscription => {
         subscription.unsubscribe();
      });
   }
}
