import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, tap, throwError } from 'rxjs';


export class Customer {
  name: string = "";
  surname: string = "";
  dni: number = 0;
  bithDate: Date = new Date("");
  phone: number = 0;
  email: string = "";
  password: string = "";
  clientState: boolean = false;
  clientVerify: boolean = false;
}

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  apiUrl:string='https://localhost:7010/api/Customer';
  constructor(private http: HttpClient) { }

  private handleError(error: Response) {
    console.log(error);
    const err = new Error('Error status code' + error.status + 'status' + error.statusText + 'statusText')
    throwError(() => err);
  }

  getCustomer(): Observable<any> {
    return this.http.get(`${this.apiUrl}`).pipe(
      tap(console.log),
      catchError(throwError)

    );
  }

  addCustomer(form: any): Observable<any> {
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

  putCustomer(id: number, form: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, form);
  }

  deleteCustomer(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  GetCustomerById(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/${id}`);
  }
}
