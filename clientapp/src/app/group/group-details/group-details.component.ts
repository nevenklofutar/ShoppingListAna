import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { MatListOption } from '@angular/material/list';
import { ActivatedRoute } from '@angular/router';
import {
   BehaviorSubject,
   combineLatest,
   forkJoin,
   Observable,
   Subject,
} from 'rxjs';
import {
   concatMap,
   filter,
   map,
   mergeMap,
   switchMap,
   tap,
} from 'rxjs/operators';
import { BaseComponent } from 'src/app/shared/components/base/base.component';
import { sortItemsBySelectedThenTitle } from 'src/app/shared/extensions';
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
   private subjectGroupId = new BehaviorSubject<number>(0);
   private groupId$ = this.subjectGroupId.asObservable();

   groupId: number;
   group: Group;
   items: Item[];

   constructor(
      private route: ActivatedRoute,
      private groupService: GroupService,
      private itemService: ItemService
   ) {
      super();

      const subParams = this.route.params.subscribe((params) => {
         this.groupId = +params['id'];
         this.subjectGroupId.next(this.groupId);
      });
      this.subscriptions.push(subParams);

      const subGroupsItems = this.groupId$
         .pipe(
            // switychmap[ umjesto merge map]
            // mergeMap(result => combineLatest([this.groupService.groups$, this.itemService.getItemsForGroup(result)])),
            switchMap((result) =>
               combineLatest([
                  this.groupService.groups$,
                  this.itemService.getItemsForGroup(result),
               ])
            )
         )
         .subscribe(([groups, items]) => {
            const index = groups.findIndex((g) => g.id == this.groupId);
            this.group = groups[index];
            this.items = items;
         });
      this.subscriptions.push(subGroupsItems);
   }

   ngOnInit(): void {}

   // onItemsSelectionChange(options: MatListOption[]) {
   //    // map these MatListOptions to their values
   //    console.log(options.map<Item>((o) => o.value));
   // }

   selectItem(item: Item) {
      const index = this.items.findIndex(i => i.id === item.id);
      let itemToUpdate = this.items[index];
      itemToUpdate.selected = !itemToUpdate.selected;
      this.items.sort(sortItemsBySelectedThenTitle);
      this.itemService.updateItem(itemToUpdate);
   }
}
