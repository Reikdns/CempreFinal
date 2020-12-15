import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error-service/handle-http-error.service';
import { HojaDeVida } from '../models/hoja-de-vida';

@Injectable({
  providedIn: 'root'
})
export class HojaDeVidaService {
  baseUrl: string;

  constructor(

    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService

  ) {
    this.baseUrl = baseUrl;
  }

  get(): Observable<HojaDeVida[]> {
    return this.http.get<HojaDeVida[]>(this.baseUrl + 'api/HojaDeVida')
      .pipe(tap(_ => this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<HojaDeVida[]>('Consultar hoja de vida', null))
      );
  }
  
  post(hojaDeVida: HojaDeVida): Observable<HojaDeVida> {
    return this.http.post<HojaDeVida>(this.baseUrl + 'api/HojaDeVida', hojaDeVida)
      .pipe(tap(_ => this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<HojaDeVida>('Registrar hoja de vida', null))
      );
  }
}


