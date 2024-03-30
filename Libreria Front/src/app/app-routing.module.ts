import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Home/Home.component';
import { LibrosComponent } from './Libros/Libros.component';
import { AgregarLibroComponent } from './Agregar-libro/Agregar-libro.component';
import { ListaLecturaComponent } from './Lista-lectura/Lista-lectura.component';
import { DetalleLibroComponent } from './detalle-libro/detalle-libro.component';

const routes: Routes = [
  {path:'libros/:id',component:DetalleLibroComponent},
  {path:'libros',component:LibrosComponent},
  {path:'addLibro',component:AgregarLibroComponent},
  {path:'',component:HomeComponent},

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


