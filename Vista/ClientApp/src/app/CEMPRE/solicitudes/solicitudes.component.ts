import { Component, OnInit } from '@angular/core';
import { HojaDeVida } from '../models/hoja-de-vida';
import { CargaJsService } from '../services/carga-js.service';
import { HojaDeVidaService } from '../services/hoja-de-vida.service';

@Component({
  selector: 'app-solicitudes',
  templateUrl: './solicitudes.component.html',
  styleUrls: ['./solicitudes.component.css']
})
export class SolicitudesComponent implements OnInit {

  hojasDeVida: HojaDeVida[];
  obj: HojaDeVida;

  constructor(private _CargaScripts: CargaJsService, private hojaDeVidaService: HojaDeVidaService) { }

  ngOnInit(): void {
    
      this.hojaDeVidaService.get().subscribe( result => {
      this.hojasDeVida = result;
      if(this.hojasDeVida){
        this.ver(this.hojasDeVida[0].identificacion);
      }
    });
  }

  ver(id:string){
    this.hojasDeVida.forEach(element => {
      if(element.identificacion == id){
        this.obj = element;
      }
    });
  }

}
