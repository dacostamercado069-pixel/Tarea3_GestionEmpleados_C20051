# Gestión de Empleados

Kristy Daniela Acosta Mercado C20051

---

## Instrucciones de ejecución

1. Abrir el proyecto en Visual Studio

2. Configurar la cadena de conexión en `appsettings.json`

3. Ejecutar el comando:

   dotnet ef database update

4. Ejecutar el proyecto

---

## Descripción de la paginación

El sistema muestra los empleados en páginas.

* Se muestran 5 empleados por página
* Se utilizan `Skip()` y `Take()`
* Permite navegar entre páginas



## Ejemplo de URL con búsqueda

/Empleados?busqueda=IT&pagina=1
