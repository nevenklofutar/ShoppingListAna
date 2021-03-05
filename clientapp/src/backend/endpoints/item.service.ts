import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { sortItemsBySelectedThenTitle } from 'src/app/shared/extensions';
import { environment } from 'src/environments/environment';
import { Item } from '../interfaces';

@Injectable({
   providedIn: 'root',
})
export class ItemService {
   private baseUrl = environment.baseUrl;

   constructor(private http: HttpClient) {}

   getItemsForGroup(groupId: number): Observable<Item[]> {
      // console.log('getItemsForGroup: ' + groupId);
      return this.http.get<Item[]>(this.baseUrl + `groups/${groupId}/items`)
         .pipe(map((items) => items.sort(sortItemsBySelectedThenTitle)));
   }

   createItem(item: Item) {}

   updateItem(item: Item) {
      this.http.put(this.baseUrl + `items/${item.id}`, item).subscribe();
   }

   deleteItem(itemId: number) {}
}
