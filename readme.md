# Biblioteca

## Descripción del proyecto:
Este proyecto es una aplicación basada en una **biblioteca virtual** que permite gestionar tus libros de forma sencilla, con funcionalidades adicionales que enriquecen la experiencia de usuario.

### Funcionalidades principales:

#### **Gestión de libros (CRUD)**
Podrás **agregar**, **eliminar**, **editar** y **visualizar** todos los libros que hayas registrado en tu biblioteca personal. Cada libro puede ser gestionado de manera intuitiva desde la interfaz principal.

#### **Listas de lectura personalizadas**
Además del CRUD básico, se ha implementado una funcionalidad para crear **listas de lectura personalizadas**. Desde el **sidebar**, podrás crear nuevas listas y agregar libros a ellas directamente desde la vista principal de libros. También tendrás la posibilidad de ver todos los libros de una lista específica, lo que facilita la organización de tus lecturas.

#### **Cambio rápido de usuario**
Para mejorar la experiencia y evitar la molestia de iniciar sesión constantemente, puedes **cambiar de usuario** desde el sidebar sin necesidad de ingresar una contraseña cada vez. Cada usuario tiene su propio conjunto de libros y listas de lectura, lo que asegura que los libros y las listas estén **asociados de forma exclusiva** a cada usuario. Por ejemplo, si el usuario "Donald Trump" añade un libro o lo incluye en una lista, ese libro quedará vinculado únicamente a él.

> [!IMPORTANT]  
> Cada usuario tiene sus listas y libros. Si agregas un libro mientras estás utilizando un usuario específico, como "Donald Trump", ese libro se asociará solo a dicho usuario, lo mismo aplica para las listas.

### Entidades de la base de datos:
1. **ListaDeLectura**
2. **Usuario**
3. **Libro**

## Capturas de pantalla:

### Panel principal
![Imagen del dashboard](images/home.png)

En esta vista puedes ver el **sidebar** que muestra los usuarios y las **Listas de Lectura**.

![Imagen del sidebar](images/expandibles.png)

### Vista de libros
Aquí puedes ver los libros registrados.

![Imagen de los libros](images/libro.png)

### Asignación de un libro a una lista de lectura
Es fácil mover libros a las listas de lectura personalizadas.

![Imagen de asignación de libro a lista](images/LibroALista.png)

### Edición de un libro
Pantalla para modificar los detalles de un libro.

![Imagen de edición de libro](images/editar.png)

### Detalles de un libro
Vista detallada de la información de un libro específico.

![Imagen del detalle de un libro](images/detalleLibro.png)
