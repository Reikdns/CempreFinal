import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './CEMPRE/nav-menu/nav-menu.component';
import { HomeComponent } from './CEMPRE/home/home.component';
import { CargaJsService } from './CEMPRE/services/carga-js.service';
import { LoginComponent } from './CEMPRE/login/login.component';
import { AppRoutingModule } from './app-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from './CEMPRE/@base/alert-modal/alert-modal.component';
import { InscripcionComponent } from './CEMPRE/inscripcion/inscripcion.component';
import { UsuarioService } from './CEMPRE/services/usuario.service';
import { HandleHttpErrorService } from './CEMPRE/@base/handle-http-error-service/handle-http-error.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    AlertModalComponent,
    InscripcionComponent
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    NgbModule
  ],
  entryComponents:[AlertModalComponent],
  providers: [
    CargaJsService,
    UsuarioService,
    HandleHttpErrorService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
