import { Component, OnInit } from '@angular/core';
import { Api } from 'src/Services/Api';
import { Libro } from 'src/Services/Interface';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
import { AgregarLibroComponent } from '../Agregar-libro/Agregar-libro.component';


@Component({
  selector: 'app-Libros',
  templateUrl: './Libros.component.html',
  styleUrls: ['./Libros.component.css']
})
export class LibrosComponent implements OnInit {

  api: Api;
  libros: Libro[] = [];
  listas: any[] = [];
  loading = false;
  listaId = ""
  editar=false;

  relacion = {
    idLibro: "",
    idLista: ""
  }

  constructor(Api: Api, private toastr: ToastrService) {
    this.api = Api;
  }

  ngOnInit(): void {
    this.api.GetDataUsuario().subscribe(e => {
      this.libros = e.Libros;
      console.log(e.Libros)
      this.listas = e.ListaDeLecturas;
      console.log(e.ListaDeLecturas)
      this.loading = true;
    })

  }

  TraerLibroDeLista() {
    console.log(this.listaId);

    if (this.listaId != "") {
      this.loading = false;
      this.api.GetLista(this.listaId).subscribe(e => {
        this.libros = e.Libros;
        this.loading = true;
      })
    }
    else {
      this.ngOnInit();
    }
  }

  EliminarLibro(id: string) {
    this.api.EliminarLibro(id).subscribe(e => {
      this.libros = this.libros.filter(x => x.Id == id);
      this.ngOnInit()
    })
  }

  EstablecerId(idLibro: string) {
    this.relacion.idLibro = idLibro;
  }

  Open(libroId = "",editar =false) {

    if(libroId != "" && libroId != '.'){
      sessionStorage.setItem('IdLibro', libroId)
    }
    else{
      sessionStorage.removeItem('IdLibro') 
    }
    
    
    this.editar = editar;
  }


  Agregar_Libro_A_Lista() {
    this.api.AgregarLibroAlista(this.relacion).subscribe(e => {
      if (e) {
        this.toastr.success("Se agrego el libro correctamente")
      } else {
        this.toastr.error("No se agrego el libro correctamente")
      }
      this.ngOnInit()
    })
  }


}
