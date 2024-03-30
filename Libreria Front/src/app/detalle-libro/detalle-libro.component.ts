import { Component, OnInit } from '@angular/core';
import { Api } from 'src/Services/Api';
import { Libro } from 'src/Services/Interface';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-detalle-libro',
  templateUrl: './detalle-libro.component.html',
  styleUrls: ['./detalle-libro.component.css']
})
export class DetalleLibroComponent implements OnInit {


  libro: Libro = {
    Titulo: '',
    Autor: '',
    Genero: '',
    NumeroPaginas: 0,
    Precio: 0,
    Descripcion: '',
    Portada: '',
    Id: '.',
    UsuarioId: '.'
  };
  titulo = "No funciona"

  constructor(Api: Api, route: ActivatedRoute) {
    const id = route.snapshot.params['id']; 

    if (id != null) {
      Api.GetLibro(id).subscribe((e:any) => {
      this.libro = e;
      console.log(this.libro)
      this.titulo=e.Titulo
      });

    }  

  }

  ngOnInit() {
  }


}
