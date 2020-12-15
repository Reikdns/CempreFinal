import { Component, OnInit, OnChanges } from '@angular/core';
import { CargaJsService } from '../services/carga-js.service';
import { FormGroup, FormBuilder, Validators, AbstractControl} from '@angular/forms';
import { Usuario } from '../models/usuario';
import { UsuarioService } from '../services/usuario.service';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from '../@base/alert-modal/alert-modal.component';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formGroup: FormGroup;
  usuario: Usuario;

  constructor(private _CargaScripts: CargaJsService, private formBuilder: FormBuilder,
    private usuarioService: UsuarioService,
    private modalService: NgbModal) {

    this._CargaScripts.cargar(["login/login"]);
    
   } 

  ngOnInit(): void {
    this.buildForm();
  }
  
  add(){
    this.usuarioService.post(this.usuario).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado de registro:";
        messageBox.componentInstance.message = '¡Usuario registrado!';
        this.usuario = p;
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

  get control(){
    return this.formGroup.controls;
  }

  onSubmit(){
    if(this.formGroup.invalid){
      return;
    }
    this.add();
  }

}
