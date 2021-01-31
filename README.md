# Cuestiones importantes para el uso

Para poder jugar al videojuego, es necesario tener algún mando, o en mejor caso, un teclado, ya que el juego original ha sido diseñado para ser jugado utilizando este último. A su vez el juego cuenta con soporte para un mando de realidad virtual permitiendo así la ejecución de este en un sistema VR

Para movernos, usamos los **controles wasd**, w para adelante, a y s para los laterales. Para el coche, hemos de subirnos utilizando la tecla T, y para encender la linterna, utilizamos la tecla l.
El objetivo del juego, es obtener las tres piezas necesarias para poder arrancar nuestro coche. Una vez que obtengamos las tres piezas, y lleguemos a nuestro coche ganamos el juego. 
Estas tres piezas se encuentran dispersas por todo el mapa. Además, también contamos con corazones, que nos darán vidas, y munición, la cual podremos utilizar para matar a los zombies pulsando el click izquierdo del ratón. Tendremos que evitar a los zombies, los cuales intentarán atacarnos y quitarnos vidas. Si nos quitan 3 vidas, perdemos.

# Hitos de programación

Los scripts del proyecto han sido desarrollados en C# en su totalidad. Empleando algunas de las técnicas que hemos aprendido en la asignatura hemos logrado implementar: 

1. Un **character controller** que nos permite controlar al jugador usando las fuerzas del motor de físicas de Unity. 
2. **Iluminación dinámica**, utilizado para la linterna del jugador, lo que nos permitirá ver mejor el escenario, ya que es de noche. También, hemos generado iluminaciones en los distintos objetos recolectables, con lo que será más fácil para el jugador verlos. Estos tienen diferentes colores dependiendo del tipo de objeto.
3. **Delegados y eventos**, utilizados a la hora de mover los zombies al objetivo, a la hora de recolectar objetos, etc.
4. **Soporte para realidad virtual**, hemos mapeado y adaptado el juego para su uso en realidad virtual.
5. **Objetos recolectables**, estos se encuentran dispersos en el mapa, y flotando e iluminados. El jugador, al pasar por encima de ellos, añade este item recolectable, que será visible en el canvas, además de que el recolectable desaparece del mapa.
6. **Sistema de puntuación**, al realizar diferentes objetivos y/o recolectar diferentes objetos, aumenta la puntuación del jugador. Por el contrario, también se penaliza al jugador, quitando puntos, en el caso de que este sea alcanzado por los zombies.
7. **Sistema de salud**, con el que el jugador puede ganar o perder vidas. Si es alcanzado por los zombies, pierde vidas. El jugador puede volver a ganar las vidas, recolectando los corazones dispersos por el mapa. Como máximo, sólo podrá tener tres corazones.
8. **Cinemáticas y menús,** se han creado diferentes cinemáticas para el inicio del juego, final, y para el menú del *Game Over*, es decir, cuando el jugador pierde la partida.
9. **Sensores**, se ha añadido una brújula, que guía al usuario hacia el norte. Esta solo se puede visualizar utilizando un teléfono móvil. Se encuentra situada justamente a la derecha de los corazones.

# Aspectos destacables del proyecto

El videojuego desarrollado se ejecuta en un sistema de realidad virtual. Tiene mecánicas jugables tales como la recolección, la salud y los disparos. Cuenta también con una interfaz la cual nos indica la salud, la puntuación y los coleccionables restantes. Los enemigos tienen implementados una IA sencilla capaz de realizar pathfinding para encontrar al jugador. A su vez el videojuego tiene cinemáticas, tanto inicial como final, que sirven de introducción y desenlace respectivamente a la historia.

# Reparto de trabajo

Hemos utilizado la aplicación *discord* para la comunicación entre los integrantes del grupo. No hemos seguido ninguna esquema de distribución para repartir las tareas del proyecto, trabajando todos en función de las necesidades de este, sin embargo mayoritariamente podría resumirse así:

- **Tomás**: 
  - Aspectos jugables:
    - Sistema de disparos
    - Soporte VR
  - Desarrollo de la escena
- **Francisco**:
  - Desarrollo de la interfaz
  - Sistema de puntuación
  - Recolección de objetos
  - Cinemáticas
- **David**:
  - IA del enemigo
  - Sensores

Cada miembro del equipo ha trabajado individualmente en sus tareas mientras que en Discord nos hemos reunido para trabajar de manera más colectiva. El desarrollo de los script ha sido desarrollado por todas las partes, ajustando los mismos a los requisitos jugables del proyecto.
En un comienzo, decidimos utilizar un sistema de almacenamiento en la nube para almacenar el proyecto, similar a un sistema git, pero desarrollado por Unity (Unity Temas), sin embargo, debido a su coste y limitaciones de capacidad, hemos decidido dividirnos las tareas por separado, y posteriormente juntar todo el material en uno.

# Gif animado de ejecución

**NOTA:** Los Gifs son muy grandes de tamaño, pueden tardar en cargar.

1. Imagen de la pantalla de carga al principio. También contiene la cinemática inicial, cuando el usuario pulsa el botón para empezar el juego.

![imgGif1](GIFs/imgGif1.gif)

2. Comienzo del juego, donde recolectamos una de las piezas, una munición, y además disparamos al zombie:

![imgGif2](GIFs/imgGif2.gif)

3. Última imagen, cuando ya tenemos todos los objetos recolectados, y nos vamos al coche final. Se muestra además, la cinemática final del juego:

![imgGif3](GIFs/imgGif3.gif)