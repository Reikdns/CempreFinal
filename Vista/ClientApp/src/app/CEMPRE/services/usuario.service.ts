import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Inject, Injectable } from '@angular/core';
import { HandleHttpErrorService } from '../@base/handle-http-error-service/handle-http-error.service';
import { Usuario } from '../models/usuario';
import { catchError, map, tap } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  baseUrl: string;

  constructor(

    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService

  ) {
    this.baseUrl = baseUrl;
  }

  get(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.baseUrl + 'api/Usuario')
      .pipe(tap(_ => this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<Usuario[]>('Consulta usuario', null))
      );
  }

  post(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(this.baseUrl + 'api/Usuario', usuario)
      .pipe(tap(_ => this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<Usuario>('Registrar usuario', null))
      );
  }
}
