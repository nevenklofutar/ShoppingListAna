import { Component } from '@angular/core';
import { BaseComponent } from 'src/app/shared/components/base/base.component';
import { GroupService } from 'src/backend/endpoints/group.service';
import { Group } from 'src/backend/interfaces';

@Component({
  selector: 'app-group-list',
  templateUrl: './group-list.component.html',
  styleUrls: ['./group-list.component.css']
})
export class GroupListComponent extends BaseComponent {
   groups: Group[] = [];

   constructor(private groupService: GroupService) {
      super();
   }

   ngOnInit(): void {
      const subscription = this.groupService.groups$
         .subscribe(result => this.groups = result);

      this.subscriptions.push(subscription);
   }
}