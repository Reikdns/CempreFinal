import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from '../@base/alert-modal/alert-modal.component';
import { HojaDeVida } from '../models/hoja-de-vida';
import { CargaJsService } from '../services/carga-js.service';
import { HojaDeVidaService } from '../services/hoja-de-vida.service';

@Component({
  selector: 'app-inscripcion',
  templateUrl: './inscripcion.component.html',
  styleUrls: ['./inscripcion.component.css']
})
export class InscripcionComponent implements OnInit {

  formGroup: FormGroup;
  hojaDeVida: HojaDeVida;

  constructor(private _CargaScripts: CargaJsService, private hojaDeVidaService: HojaDeVidaService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal)
  {
    this._CargaScripts.cargar(["login/login"]);
  }

  ngOnInit(): void {
    this.buildForm();
  }

  add(){
    this.hojaDeVidaService.post(this.hojaDeVida).subscribe(p => {
       if (p != null) {
        this.hojaDeVida = p;
      }
     });
     const messageBox = this.modalService.open(AlertModalComponent)
     messageBox.componentInstance.title = "Resultado de envio:";
     messageBox.componentInstance.message = '¡Su hoja de vida ha sido enviada!';
  }

  private buildForm()
  {
    this.hojaDeVida = new HojaDeVida();
    this.hojaDeVida.identificacion = '';
    this.hojaDeVida.nombre = '';
    this.hojaDeVida.primerApellido = '';
    this.hojaDeVida.segundoApellido = '';
    this.hojaDeVida.fechaDeNacimiento = null;
    this.hojaDeVida.lugarDeNacimiento = '';
    this.hojaDeVida.correoElectronico = '';
    this.hojaDeVida.telefono = '';
    this.hojaDeVida.programa = '';
    this.hojaDeVida.ciudadActual = '';
    this.hojaDeVida.direccionActual = '';
    this.hojaDeVida.epsActual = '';
    this.hojaDeVida.estadoCivil = '';
    this.hojaDeVida.estudiosRealizados = '';
    this.hojaDeVida.idiomas = '';
    this.hojaDeVida.distincionesYHonoresRecibidos = '';
    this.hojaDeVida.seminariosYCursosAsistidos = '';
    this.hojaDeVida.proyectosRealizados = '';
    this.hojaDeVida.experienciaLaboral = '';
    this.hojaDeVida.areasDeInteresParaPracticas = '';
    this.hojaDeVida.conocimientoPracticaInformatica = '';
    this.hojaDeVida.fechaDeSolicitud = null;

    this.formGroup = this.formBuilder.group({

      identificacion: [this.hojaDeVida.identificacion, Validators.required],
      nombre: [this.hojaDeVida.nombre, Validators.required],
      primerApellido: [this.hojaDeVida.primerApellido, Validators.required],
      segundoApellido: [this.hojaDeVida.segundoApellido, Validators.required],
      fechaDeNacimiento: [this.hojaDeVida.fechaDeNacimiento, Validators.required],
      lugarDeNacimiento: [this.hojaDeVida.lugarDeNacimiento, Validators.required],
      correoElectronico: [this.hojaDeVida.correoElectronico, [Validators.required, Validators.email]],
      telefono: [this.hojaDeVida.telefono, Validators.required],
      programa: [this.hojaDeVida.programa, Validators.required],
      ciudadActual: [this.hojaDeVida.ciudadActual, Validators.required],
      direccionActual: [this.hojaDeVida.direccionActual, Validators.required],
      epsActual: [this.hojaDeVida.epsActual, Validators.required],
      estadoCivil: [this.hojaDeVida.estadoCivil, Validators.required],
      estudiosRealizados: [this.hojaDeVida.estudiosRealizados, Validators.required],
      idiomas: [this.hojaDeVida.idiomas, Validators.required],
      distincionesYHonoresRecibidos: [this.hojaDeVida.distincionesYHonoresRecibidos, Validators.required],
      seminariosYCursosAsistidos: [this.hojaDeVida.seminariosYCursosAsistidos, Validators.required],
      proyectosRealizados: [this.hojaDeVida.proyectosRealizados, Validators.required],   
      experienciaLaboral: [this.hojaDeVida.experienciaLaboral, Validators.required],
      areasDeInteresParaPracticas: [this.hojaDeVida.areasDeInteresParaPracticas, Validators.required],
      conocimientoPracticaInformatica: [this.hojaDeVida.conocimientoPracticaInformatica, Validators.required],
      fechaDeSolicitud: [this.hojaDeVida.fechaDeSolicitud, Validators.required]   

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
