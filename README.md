# Web-Api
##Películas
Debido a la estructura del JSON tenemos dos modelos: actores y películas.

En resources guardamos el JSON.

En contracts definimos los métodos que usaemos con las variables que le pasamos.

En controllers definimos un controlador para cada método.
El primero obtiene una lista de todos los actores.
El segundo crea un registro llamando al repositorio AddActor. Si hay errores lanza un BadRequest.
Al segundo se le pasa un id y obtiene el actor siguiedo la misma lógica de antes. Esta vez el error es un NotFound.
El tercero recibe los parámetros id, nombre y apellidos y actualiza el registro del usuario.
El último método sigue la misma lógica que el de añadir actores.

En el repositorio definimos la lógica para método.
Pero primero almacenamos en una variable la ruta del JSON
