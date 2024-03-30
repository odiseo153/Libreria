import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Libro, Usuario } from './Interface';


@Injectable({
    providedIn: 'root'
})

export class Api 
{

    url = "http://localhost:5020/"

    constructor(private http: HttpClient) {}

    GetLibros():Observable<any>{
        return this.http.get(this.url+'Libro');
    }

    GetLibro(id:string):Observable<any>{
        return this.http.get(this.url+'Libro/'+id);
    }

    ActualizarLista(listaActualizada:any){
        console.log(listaActualizada)
        return this.http.put(this.url+'Lista',listaActualizada);
    }

    ActualizarUsuario(user:any){
        return this.http.put(this.url+'Usuario',user);
    }

    ActualizarLibro(Libro:Libro){
        return this.http.put(this.url+'Libro',Libro);
    }
    
    EliminarUsuario(id:string):Observable<any>{
        return this.http.delete(this.url+'Usuario/'+id);
    }

    EliminarLista(id:string):Observable<any>{
        return this.http.delete(this.url+'Lista/'+id);
    }

    EliminarLibro(id:string):Observable<any>{
        return this.http.delete(this.url+'Libro/'+id);
    }

    GetUsuarios():Observable<any>{
        return this.http.get(this.url+'Usuario');
    }

    GetDataUsuario():Observable<any>{
        const idUsuario = localStorage.getItem('idUsuario');
        return this.http.get(this.url+'Usuario/'+idUsuario);
    }

    GetLista(id:string):Observable<any>{
        return this.http.get(this.url+'Lista/'+id);
    }

    AgregarLibro(libro:Libro){
        return this.http.post(this.url+'Libro',libro);
    }
    AgregarLibroAlista(relacion:any){
        return this.http.post(this.url+'LibroLista',relacion);
    }

    AgregarUsuario(usuario:Usuario){
        return this.http.post(this.url+'Usuario',usuario);
    }

    AgregarLista(lista:any){
        return this.http.post(this.url+'Lista',lista);
    }

}




