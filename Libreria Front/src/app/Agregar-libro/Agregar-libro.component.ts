import { Component, OnInit } from '@angular/core';
import { Api } from 'src/Services/Api';
import { Libro } from 'src/Services/Interface';
import { ToastrService } from 'ngx-toastr';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-Agregar-libro',
  templateUrl: './Agregar-libro.component.html',
  styleUrls: ['./Agregar-libro.component.css']
})
export class AgregarLibroComponent implements OnInit {

  imagen: string = "https://img.wattpad.com/81f164ba251c436ea74e9d13c2a31166eb3b4589/68747470733a2f2f73332e616d617a6f6e6177732e636f6d2f776174747061642d6d656469612d736572766963652f53746f7279496d6167652f4658486a733959424535413134513d3d2d313034323839353830392e313636653135643962353839316266643939303833333532343035392e6a7067?s=fit&w=720&h=720"
  usuarioId = localStorage.getItem('idUsuario') || '.';
  libroId = ''

  libroForm:FormGroup  = new FormGroup({
    Titulo: new FormControl("",[Validators.required]),
    Autor: new FormControl("",[Validators.required]),
    Genero: new FormControl("",[Validators.required]),
    NumeroPaginas: new FormControl(0),
    Precio: new FormControl(0),
    Descripcion: new FormControl("",[Validators.required]),
    Portada:new FormControl("",[Validators.required]),
  });
 
  libro: Libro = {
    Titulo: '',
    Autor: '',
    Genero: '',
    NumeroPaginas: 0,
    Precio: 0,
    Descripcion: '',
    Portada: '',
    Id: '.',
    UsuarioId: this.usuarioId
  };
  api: Api;

  constructor(Api: Api, private toastr: ToastrService) {
    this.api = Api;
    this.libroId = sessionStorage.getItem("IdLibro") || "";

    if (this.libroId != "") {
      this.api.GetLibro(this.libroId).subscribe((e:any) => {
        this.libro = e;
        console.log(this.libro)
      })
    }

  }


  ngOnInit() { }

  validarLibro(): boolean {
    const camposVacios: string[] = [];

    // Recorrer las propiedades de la interfaz
    for (const propiedad in this.libro) {

      const libroAny = this.libro as any;

      // Si el valor de la propiedad es undefined o una cadena vacía, agregarlo a la lista de campos vacíos
      if (libroAny[propiedad] === undefined || libroAny[propiedad] === '') {
        camposVacios.push(propiedad);
      }
    }

    // Si hay campos vacíos, mostrar una alerta y devolver false
    if (camposVacios.length > 0) {
      const mensajeAlerta = `Los siguientes campos están vacíos: ${camposVacios.join(
        ', '
      )}`;
      //alert(mensajeAlerta);
      this.toastr.error(mensajeAlerta);
      return false;
    }
    // Si no hay campos vacíos, devolver true
    return true;
  }

QuitarModoEditar(){
  this.libro = {
    Titulo: '',
    Autor: '',
    Genero: '',
    NumeroPaginas: 0,
    Precio: 0,
    Descripcion: '',
    Portada: '',
    Id: '.',
    UsuarioId: this.usuarioId
  };
  sessionStorage.removeItem('IdLibro')
  window.location.href = "/libros";
}

  Accion() {
    const validar = this.validarLibro();

    if (validar && this.libroId == "") {
      this.api.AgregarLibro(this.libro).subscribe((e) => {
        console.log(e);
        if (e != null) {
          this.toastr.success("Se agrego el libro correctamente");
          this.libro = {
            Titulo: '',
            Autor: '',
            Genero: '',
            NumeroPaginas: 0,
            Precio: 0,
            Descripcion: '',
            Portada: '',
            Id: '.',
            UsuarioId: this.usuarioId
          };
        }
      });
    }


    if (validar && this.libroId != "") {
      this.api.ActualizarLibro(this.libro).subscribe((e) => { 
          this.toastr.success("Se Actualizo el libro correctamente");
          this.libro = {
            Titulo: '',
            Autor: '',
            Genero: '',
            NumeroPaginas: 0,
            Precio: 0,
            Descripcion: '',
            Portada: '',
            Id: '.',
            UsuarioId: this.usuarioId
          };
          sessionStorage.removeItem('IdLibro')
          window.location.href = '/';
      });
    }
  }


}
