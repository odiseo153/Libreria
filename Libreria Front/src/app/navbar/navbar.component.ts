import { Component, OnInit } from '@angular/core';
import { Api } from 'src/Services/Api';
import { Usuario } from 'src/Services/Interface';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})


export class NavbarComponent implements OnInit {


  vista: string = 'home';
  usuarioId = localStorage.getItem('idUsuario') || '.';
  imagen: string = "https://wallpapers-clan.com/wp-content/uploads/2023/01/anime-aesthetic-boy-pfp-1.jpg";
  mostrarLista = false;
  campoLista = false;
  listas: any[] = [];
  mostrarUsuarios = false;
  usuarios: Usuario[] = [];
  campoUsuario = false;

  api: Api;

  usuario: Usuario = {
    Id: '',
    ImagenUrl: '',
    Nombre: ''
  };

  usuarioActual: Usuario = {
    Id: '',
    ImagenUrl: '',
    Nombre: ''
  };

  lista = {
    Nombre: "",
    usuarioId: this.usuarioId
  }

  constructor(Api: Api) {
    this.api = Api;

    Api.GetUsuarios().subscribe((e) => {
      this.usuarios = e;
      console.log(e)
    });

    Api.GetDataUsuario().subscribe((e) => {
      this.listas = e.ListaDeLecturas;
      this.usuarioActual = e;
      //console.log(e)
      //console.log(e.ListaDeLecturas.$values.filter((item:any, index:number) => index !== 0))
    });

  }



  ngOnInit() {
    /*
    this.api.GetUsuarios().subscribe((e) => {
      this.usuarios = e.$values;
      console.log(e.$values)   
    });
*/
  }

  cambiarVista(vista: string) {
    this.vista = vista;
  }

  CambiarDeUsuario(id: string) {
    localStorage.setItem('idUsuario', id);
    this.ngOnInit();
    window.location.reload();

  }

  activarEdicion(item: any,user=false) {
    item.editando = item.editando ? false : true; // Agrega una propiedad "editando" al objeto "item" para controlar el estado de edición

  }

  Eliminar(id: string, user = true) {
    console.log(id)

    if (user) {
      this.api.EliminarUsuario(id).subscribe((e) => {
        console.log(e)
        this.usuarios = this.usuarios.filter(x => x.Id != id);
      });
    }
    else {
      this.api.EliminarLista(id).subscribe((e) => {
        console.log(e)
        this.listas = this.listas.filter(x => x.Id != id);

      });
    }
  }

  ActualizarLista(item: any) {

    const lista = {
      nombre: item.Nombre,
      listaId: item.Id
    };

    this.api.ActualizarLista(lista).subscribe((e: any) => {
      item.Nombre = e.nombre;
      item.editando = item.editando ? false : true;
    });


  }

  ActualizarUsuario() {
    this.api.ActualizarUsuario(this.usuarioActual).subscribe((e:any) => {
    console.log(e)
    this.usuarioActual.Nombre=e.nombre;
    });
  }

  verCampoAgregar(cambio = true) {
    if (cambio) {
      this.campoUsuario = this.campoUsuario ? false : true;
    }
    else {
      this.campoLista = this.campoLista ? false : true;
    }
    this.ngOnInit();
  }


  Agregar(cambio = true) {
    if (cambio) {
      this.api.AgregarUsuario(this.usuario).subscribe((e: any) => {
        console.log(e)
      
        const newUser: Usuario = {
          Nombre: e.nombre,
          ImagenUrl: e.imagenUrl,
          Id: e.id
        }
      
        this.usuario.Nombre = "";
        this.usuario.ImagenUrl = "";
        this.campoUsuario = this.campoUsuario ? false : true; 

        this.usuarios.push(newUser);
      });
    }
    else {
      this.api.AgregarLista(this.lista).subscribe((e: any) => {
        //console.log(e) 

        const lista = {
          Nombre: e.nombre,
          usuarioId: e.usuarioId
        };

        this.listas.push(lista);
        this.lista.Nombre = "";
        this.campoLista = this.campoLista ? false : true;
      });
    }
  }

  Mostrar(cambio = true) {
    if (cambio) {
      this.mostrarUsuarios = this.mostrarUsuarios ? false : true
    }
    else {
      this.mostrarLista = this.mostrarLista ? false : true
    }

  }





}
