import { Component, OnInit, OnChanges } from '@angular/core';
import { CargaJsService } from '../services/carga-js.service';
import { FormGroup, FormBuilder, Validators, AbstractControl} from '@angular/forms';
import { Usuario } from '../models/usuario';
import { UsuarioService } from '../services/usuario.service';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from '../@base/alert-modal/alert-modal.component';
import { AuthenticationService } from '../services/authentication.service';
import { ActivatedRoute, Router } from '@angular/router';


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
  loading: false;
  submitted: false;
  returnUrl: string;

  constructor(private _CargaScripts: CargaJsService, private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private usuarioService: UsuarioService,
    private modalService: NgbModal,
    private authtenticationService: AuthenticationService) {

    this._CargaScripts.cargar(["login/login"]);
    
    if (this.authtenticationService.currentUserValue) {
      this.router.navigate(['/']);
    }
   } 

  ngOnInit(): void {
    this.buildForm();
    this.buildFormLogin();
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get f() { return this.formGroupLogin.controls; }

  onSubmit(){
    if(this.formGroup.invalid){
      return;
    }
    this.add();
  }

  SumbitLogin(){
    if(this.formGroupLogin.invalid){
      return;
    }
    console.log("aaaaaaaaaaa");
    this.addLogin();
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
        this.router.navigate(['/']);
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





}
