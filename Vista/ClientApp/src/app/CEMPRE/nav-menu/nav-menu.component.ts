import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../services/authentication.service';
import { CargaJsService } from '../services/carga-js.service';
import { Usuario } from '../models/usuario';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  currentUser: Usuario;

  constructor(private _CargaScripts: CargaJsService, private authtenticationService: AuthenticationService, private router: Router) {

    this.authtenticationService.currentUser.subscribe(x => this.currentUser = x);

  }

  ngOnInit(): void {
    this._CargaScripts.cargar(["nav-menu/nav-menu"]);
    this._CargaScripts.cargar(["General/gestionarElemento"]);
  }

  logout() {
    this.authtenticationService.logout();
    this.router.navigate(['/login']);
  }

}
