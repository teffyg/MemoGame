Welcome to MEMO, a simple console memory game.


El juego consiste en un tablero (matriz NxM), donde cada cuadrado (Nx, My) contiene una carta.
El inciar el juego se le presenta al usuario un menu de opciones con la dificultad. 
    Facil -> matriz (5, 4), Segundos de cartas al descubierto = 5 
    Intermedio -> matriz (6, 6), Segundos de cartas al descubierto = 4 
    Experto -> matriz (8, 8), Segundos de cartas al descubierto = 3


Luego se da inicio al juego, y se presenta al usuario el tablero con ningun par de cartas al descubierto.
(Al uniciar el juego todas las cartas estan boca abajo).
En cada turno, el usuario debe ingresar dos posiciones del tablero (Nx1, My1), (Nx2, My2) donde imagina hay dos cartas iguales.
Siguiente a esto, debe imprimirse el tablero con las posiciones seleccionadas descubiertas por X segundos.

Al finalizar cada turno se debe imprimir el estado actual del tablero (con las cartas adivinadas) 
y permitir al usuario jugar otro turno o mostrar un mensaje de fin de partida.

El juego termina cuando el usuario adivina todas los pares.

