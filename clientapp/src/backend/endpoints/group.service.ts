import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { tap } from "rxjs/operators";
import { environment } from "src/environments/environment";
import { Group, GroupForUpsert } from "../interfaces";

@Injectable({
   providedIn: 'root'
})
export class GroupService {
   private baseUrl = environment.baseUrl;

   private groupsSubject = new BehaviorSubject<Group[]>([]);
   groups$: Observable<Group[]> = this.groupsSubject.asObservable();

   constructor(private http: HttpClient) {
      // console.log('GroupService activated');
      this.getAllGroups();
   }

   private getAllGroups() {
      this.http.get<Group[]>(this.baseUrl + 'groups')
         .subscribe(result => {
            // console.log('get all groups');
            this.groupsSubject.next(result);
         });
   }

   createGroup(groupForUpsert: GroupForUpsert) {
      return this.http.post(this.baseUrl + '/groups', groupForUpsert);
   }

   updateGroup(groupForUpsert: GroupForUpsert) {
      return this.http.put(this.baseUrl + '/groups', groupForUpsert);
   }

   deleteGroup(groupId: number) {
      return this.http.delete(this.baseUrl + `/groups/${groupId}`);
   }
}