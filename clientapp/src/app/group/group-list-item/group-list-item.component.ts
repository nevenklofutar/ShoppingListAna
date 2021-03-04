import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Group } from 'src/backend/interfaces';
import { GroupListComponent } from '../group-list/group-list.component';

@Component({
   selector: 'app-group-list-item',
   templateUrl: './group-list-item.component.html',
   styleUrls: ['./group-list-item.component.css'],
})
export class GroupListItemComponent implements OnInit {
   @Input() group: Group | undefined;

   constructor(private router: Router) {}

   ngOnInit(): void {}

   showGroupDetails() {
      this.router.navigate([`/groups/${this.group?.id}`]);
   }
}
