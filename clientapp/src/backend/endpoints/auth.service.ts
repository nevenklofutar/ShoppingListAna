import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserForLogin, UserForRegister } from '../interfaces';

@Injectable({
   providedIn: 'root',
})
export class AuthService {
   private baseUrl = environment.baseUrl;

   constructor(private http: HttpClient) {}

   login(userForLogin: UserForLogin) {
      // return this.http.post(this.baseUrl + 'auth/login', userForLogin);
   }

   register(userForRegister: UserForRegister) {
      // return this.http.post(this.baseUrl + 'auth/register', userForRegister);
   }
}
