import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
   BehaviorSubject,
   combineLatest,
   forkJoin,
   Observable,
   Subject,
} from 'rxjs';
import { concatMap, filter, map, mergeMap, switchMap, tap } from 'rxjs/operators';
import { BaseComponent } from 'src/app/shared/components/base/base.component';
import { GroupService } from 'src/backend/endpoints/group.service';
import { ItemService } from 'src/backend/endpoints/item.service';
import { Group, Item } from 'src/backend/interfaces';

@Component({
   selector: 'app-group-details',
   templateUrl: './group-details.component.html',
   styleUrls: ['./group-details.component.css'],
   // changeDetection: ChangeDetectionStrategy.OnPush
})
export class GroupDetailsComponent extends BaseComponent {
   groupId: number;
   group: Group;
   items: Item[];

   constructor(
      private route: ActivatedRoute,
      private groupService: GroupService,
      private itemService: ItemService
   ) {
      super();

      const subParams = this.route.params
         .subscribe((params) => {
            this.groupId = +params['id'];
            console.log('got param: ' + this.groupId);
         });
      this.subscriptions.push(subParams);

      const subGroups = this.groupService.groups$
         .pipe(
            map(groups => groups.filter(group => group.id === this.groupId))
         ).subscribe(result => {this.group = result[0]; console.log(result)});
      this.subscriptions.push(subGroups);

      const subItems = this.itemService.getItemsForGroup(this.groupId)
         .subscribe(items => this.items = items);
      this.subscriptions.push(subItems);

      // const subGroupsItems = this.groupId$
      //    .pipe(
      //       // tap(result => console.log('this.groupId$: ' + result)),\
      //       // switychmap[ umjesto merge map]
      //       mergeMap(result => combineLatest([this.groupService.groups$, this.itemService.getItemsForGroup(result)])),
      //    ).subscribe(
      //       ([groups, items]) => {
      //          console.log('result groups');
      //          console.log(groups);
      //          console.log('result items');
      //          console.log(items);

      //          const index = groups.findIndex(g => g.id == this.groupId)
      //          this.group = groups[index];
      //          this.items = items;
      //       }
      //    );
      // this.subscriptions.push(subGroupsItems);
   }

   ngOnInit(): void {

   }

   selectItem(item: Item) {
      console.log(item.title);
   }
}
