# AlkemyChallange

<h3>CHALLENGE C# - ALKEMY LABS</h3>

<h3>Requerimientos</h3>
<p>Deberás crear una aplicación en C# utilizando el framework MVC. El objetivo es simular
una aplicación web donde los alumnos de una universidad puedan inscribirse a las
materias que desean cursar.</p>

<h3>Base de datos</h3>
<p>Leyendo los requerimientos deberás armar la base de datos que consideres apropiada
para que todo funcione correctamente. El tipo de base de datos debe ser relacional, no
importa que sea MySQL o SQL Server. Todos los nombres de tablas, columnas, índices
deben estar en inglés y usar underscore para separar palabras.</p>
<p>Es necesario que utilices Entity Frameworks para acceder a la base de datos.
Registro</p>
<p>En la aplicación hay dos tipos de usuarios: administrador de sitio y alumno.
Ambos utilizan el mismo login, especificando si son alumnos o administradores.
El administrador podrá gestionar las materias, profesores, cupos de inscripción.
El alumno ingresa con su DNI y legajo y podrá seleccionar las materias en las que desea
inscribirse. Tomar como premisa que no hay materias correlativas y todos los alumnos
regulares se encuentran registrados en la base de datos.</p>

<h3>El usuario administrador podrá realizar las siguientes acciones:</h3>

Gestionar los Profesores de la Universidad<br>
<ul>
  <li>Nombre</li>
  <li>Apellido</li>
  <li>DNI</li>
  <li>Activo</li>
</ul>


Gestionar las Materias a ofrecer<br>

<ul>
  <li>Nombre</li>
  <li>Horario</li>
  <li>Profesor</li>
  <li>Cupo máximo de alumnos</li>
</ul>

El alumno podrá realizar las siguientes acciones<br>

<ul>
  <li>Listar todas las materias que estén disponibles</li>
  <li>Entrar a la materia, ver la descripción y ver la información de la misma</li>
  <li>Inscribirse en dicha materia.</li>
 
</ul>

<h3>Frontend</h3>

Puedes llenar las vistas desde el Backend, devolviendo un modelo al View desde el
controller, o puedes utilizar librerías como Jquery que realicen las llamadas a los
controladores y llenen las vistas.<br>

<h3>Rutas y Seguridad</h3>

Si un usuario no autenticado intenta acceder a alguna url de la plataforma, deberá ser
redirigido al login.

<h3>Criterios a Evaluar</h3>

Diseño responsive, moderno, intuitivo

Puede ser algo minimalista, sencillo, pero funcional<br>
Se puede usar cualquier framework CSS: Bootstrap, Materialize<br>

<ul>
  <li>Conocimientos generales de C#</li>
  <li>Conocimientos básicos / intermedios de Jquery</li>
  <li>Correcto uso de los controllers</li>
  <li>Correcto uso de los modelos, relaciones, atributos</li>
  <li>Validación de todos los formularios</li>
  <li>Seguridad</li>
  <li>Que usuarios alumnos no ingresen a rutas de usuarios administradores</li>
  <li>Buenas prácticas de codificación</li>
  <li>Correcto diseño de la base de datos</li>
  <li>Optimización de las tablas</li>
  
</ul>

<h3>Bonus</h3>

Se requiere que implementes al menos uno de estos puntos (a elección)<br>

1.- En listado de materias
<ul> 
  <li>Que aparezcan en orden alfabético</li>
  <li>Mostrar la cantidad de cupos que quedan para inscribirse en cada una</li> 
</ul>

2.- En la inscripción de materias

<ul>
  <li>No permitir que un alumno se inscriba en dos materiales cuyos horarios
están solapados
</li> 
</ul>

3.- Utilizar el Patrón de diseño Unit to Work para los repositorios
