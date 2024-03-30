import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './Home/Home.component';
import { HttpClientModule } from '@angular/common/http';
import { NavbarComponent } from './navbar/navbar.component';
import { LibrosComponent } from './Libros/Libros.component';
import { AgregarLibroComponent } from './Agregar-libro/Agregar-libro.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ListaLecturaComponent } from './Lista-lectura/Lista-lectura.component';
import { DetalleLibroComponent } from './detalle-libro/detalle-libro.component';
import { LoadingComponent } from './loading/loading.component';



@NgModule({
  declarations: [								
    AppComponent,
      HomeComponent,
      NavbarComponent,
      LibrosComponent,
      AgregarLibroComponent,
      ListaLecturaComponent,
      DetalleLibroComponent,
      LoadingComponent,
      DetalleLibroComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule, 
    ToastrModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})


export class AppModule { }
