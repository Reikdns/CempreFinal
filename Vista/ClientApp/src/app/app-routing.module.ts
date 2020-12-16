import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './CEMPRE/login/login.component';
import { HomeComponent } from './CEMPRE/home/home.component';
import { InscripcionComponent } from './CEMPRE/inscripcion/inscripcion.component';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },
  { 
    path: '', 
    component: LoginComponent, 
    pathMatch: 'full' 
  },
  {
    path: 'inscripcion',
    component: InscripcionComponent
  }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
