import { Component, OnInit } from '@angular/core';
import { CargaJsService } from '../services/carga-js.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  constructor(private _CargaScript:CargaJsService){

  }

  ngOnInit(): void {
    this._CargaScript.cargar(["General/gestionarElemento"]);
  }

}
