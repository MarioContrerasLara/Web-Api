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
Pero primero almacenamos en una constante la ruta del JSON

GetActorsFromFile se encarga de leer el archivo json y guardarlo en una variable
UpdateActores se encarga de acceder al archivo y guardar cambios.
GetActors se encarga de almacenar y formatear el JSON en una variable.
AddActor tiene como parámetro el actor. Se almacena en una variable los actores y se busca por id el actor. Si no está se lanza la excepción.
Si esta, se llama a UpdateActores.
DeleteActor sigue la misma lógica que AddActor utilizando Remove.
GetActorById tiene como parámetro el id que es entero. Si se encuentra devuelve actor que se define para encontrar el objeto.
UpdateActor sigue la misma lógica que GetActorById.
