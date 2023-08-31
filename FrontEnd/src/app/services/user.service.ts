import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, tap, throwError } from 'rxjs';


export class User {
  name: string = "";
  email: string = "";
  password: string = "";

}
@Injectable({
  providedIn: 'root'
})
export class UserService {

  apiUrl:string='https://localhost:7010/api/User';
  constructor(private http: HttpClient) { }

  private handleError(error: Response) {
    console.log(error);
    const err = new Error('Error status code' + error.status + 'status' + error.statusText + 'statusText')
    throwError(() => err);
  }

  GetAllUsers(): Observable<any> {
    return this.http.get(`${this.apiUrl}`).pipe(
      tap(console.log),
      catchError(throwError)

    );
  }

  AddUser(form: any): Observable<any> {
    return this.http.post(`${this.apiUrl}`, form, {
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      }
    }).pipe(
      tap(console.log),
      catchError(throwError)
    );
  }

  UpdateUser(id: number, form: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, form);
  }

  DeleteUser(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  GetUserById(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/${id}`);
  }

}
