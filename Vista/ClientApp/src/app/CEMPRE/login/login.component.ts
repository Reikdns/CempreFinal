import { Component, OnInit, OnChanges } from '@angular/core';
import { CargaJsService } from '../services/carga-js.service';
import { FormGroup, FormBuilder, Validators, AbstractControl} from '@angular/forms';
import { Usuario } from '../models/usuario';
import { UsuarioService } from '../services/usuario.service';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from '../@base/alert-modal/alert-modal.component';
import { AuthenticationService } from '../services/authentication.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formGroup: FormGroup;
  formGroupLogin: FormGroup;
  usuario: Usuario;
  usuarioLogin: Usuario;

  constructor(private _CargaScripts: CargaJsService, private formBuilder: FormBuilder,
    private usuarioService: UsuarioService,
    private modalService: NgbModal,
    private authtenticationService: AuthenticationService) {

    this._CargaScripts.cargar(["login/login"]);
    
   } 

  ngOnInit(): void {
    this.buildForm();
    this.buildFormLogin();
  }
  
  add(){
    this.usuario.rol = "aspirante";
    this.usuarioService.post(this.usuario).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado de registro:";
        messageBox.componentInstance.message = '¡Usuario registrado!';
        this.usuario = p;
      }
    });
  }

  addLogin(){
    
    this.authtenticationService.login(this.usuarioLogin).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado de inicio de sesion:";
        messageBox.componentInstance.message = '¡Inicio de seccion correctamente!';
        this.usuarioLogin = p;
      }
    });
  }

  private buildForm(){
    this.usuario = new Usuario();
    this.usuario.identificacion = '';
    this.usuario.nombre = '';
    this.usuario.correoElectronico = '';
    this.usuario.claveDeIngreso = '';

    this.formGroup = this.formBuilder.group({
      identificacion: [this.usuario.identificacion, Validators.required],
      nombre: [this.usuario.nombre, Validators.required],
      correoElectronico: [this.usuario.correoElectronico, [Validators.required, Validators.email]],
      claveDeIngreso: [this.usuario.claveDeIngreso, Validators.required]
    });
  }

  private buildFormLogin(){
    this.usuarioLogin = new Usuario();
    this.usuarioLogin.correoElectronico = '';
    this.usuarioLogin.claveDeIngreso = '';
    this.usuarioLogin.identificacion='';
    this.usuarioLogin.rol='';
    this.usuarioLogin.nombre='';
    this.usuarioLogin.token='';



    this.formGroupLogin = this.formBuilder.group({
      correoElectronico: [this.usuarioLogin.correoElectronico,[Validators.required]],
      claveDeIngreso: [this.usuarioLogin.claveDeIngreso, Validators.required]
    })
  }

  get control(){
    return this.formGroup.controls;
  }

  get controlLogin(){
    return this.formGroupLogin.controls;
  }

  SumbitLogin(){
    if(this.formGroupLogin.invalid){
      return;
    }
    console.log("aaaaaaaaaaa");
    this.addLogin();
  }

  onSubmit(){
    if(this.formGroup.invalid){
      return;
    }
    this.add();
  }

}
