import { Component, OnInit } from '@angular/core';
import { CargaJsService } from '../services/carga-js.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {


  constructor(private _CargaScripts: CargaJsService){

  }

  ngOnInit(): void {
    this._CargaScripts.cargar(["nav-menu/nav-menu"]);
    this._CargaScripts.cargar(["General/gestionarElemento"]);
  }

}
