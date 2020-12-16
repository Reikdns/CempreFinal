import { Inject, Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Usuario } from '../models/usuario';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error-service/handle-http-error.service';
import { map } from 'rxjs/operators';
import { tap, catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private currentUserSubject: BehaviorSubject<Usuario>;
  public currentUser: Observable<Usuario>;
  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.currentUserSubject = new BehaviorSubject<Usuario>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
    this.baseUrl = baseUrl;
  }

  public get currentUserValue(): Usuario {
    return this.currentUserSubject.value;
  }

  login(usuario:Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(this.baseUrl + 'api/Login', usuario)
      .pipe(map(user => {
        // store user and jwt token in local storage to keep user logged in between page refreshes
        localStorage.setItem('currentUser', JSON.stringify(user));
        this.currentUserSubject.next(user);
        return user;
      }),tap(_ => this.handleErrorService.log('Logeado')),
      catchError(this.handleErrorService.handleError<Usuario>('Acceso denegado', null)));
      
  }
  post(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(this.baseUrl + 'api/Usuario', usuario)
      .pipe(tap(_ => this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<Usuario>('Registrar usuario', null))
      );
  }
  


  
  
  /* post(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(this.baseUrl + 'api/Usuario', usuario)
      .pipe(tap(_ => this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<Usuario>('Registrar usuario', null))
      );
  } */


  logout() {
    // remove user from local storage and set current user to null
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }




}
