import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { ItemForUpsert } from "../interfaces";

@Injectable({
   providedIn: 'root'
})
export class ItemService {
   baseUrl = environment.baseUrl;

   constructor(private http: HttpClient) {}

   getItem(itemId: number) {}

   getItemsForGroup(groupId: number) {}

   createItem(itemForUpsert: ItemForUpsert) {}

   updateItem(itemForUpsert: ItemForUpsert) {}

   deleteItem(itemId: number) {}
}