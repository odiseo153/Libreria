export interface Libro {
    Titulo: string;
    Autor: string;
    Genero: string;
    NumeroPaginas: number;
    Precio: number;
    Descripcion: string;
    Portada: string;
    Id: string;
    UsuarioId: string;
  }

  export interface Usuario {
    Nombre: string;
    ImagenUrl:string;
    Id: string;
    editando?:boolean;
  }



