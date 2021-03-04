export interface UserForLogin {
   username: string;
   password: string;
}

export interface UserForRegister {
   firstename: string;
   lastname: string;
   email: string;
   username: string;
   password: string;
}

export interface GroupForUpsert {
   id: number;
   title: string;
   createdBy: number;
}

export interface ItemForUpsert {
   id: number;
   title: string;
   groupId: number;
   createdBy: number;
   selected: boolean;
}

export interface Group {
   id: number;
   title: string;
   createdBy: number;
   createdOn: Date;
}

export interface Item {
   id: number;
   title: string;
   groupId: number;
   createdBy: number;
   createdOn: Date;
   selected: boolean;
}