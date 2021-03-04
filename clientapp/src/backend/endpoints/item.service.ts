import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Item, ItemForUpsert } from "../interfaces";

@Injectable({
   providedIn: 'root'
})
export class ItemService {
   private baseUrl = environment.baseUrl;

   constructor(private http: HttpClient) {}

   getItemsForGroup(groupId: number): Observable<Item[]> {
      // console.log('getItemsForGroup: ' + groupId);
      return this.http.get<Item[]>(this.baseUrl + `groups/${groupId}/items`);
   }

   createItem(itemForUpsert: ItemForUpsert) {}

   updateItem(itemForUpsert: ItemForUpsert) {}

   deleteItem(itemId: number) {}
}