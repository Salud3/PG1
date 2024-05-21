#Programacion Grafica V1.0.0

Muestra de Shaders y Ejemplos de aplicacion, por medio de shadergraph y crea movimientos por medio de algunos scripts


Scripts:

- MakeCube: Crea vertices a partir de vectores en espacio de la escena, los une renderizando caras de un cubo creando un mapa Uv's
- MatrixCube : Mueve un objeto con respecto a una posicion y al delta de esta posicion.
- MatrixMovement: Rota objetos utilizando los vertices de MakeCube.
- Flauros master: Controla Las rotaciones de cada triangulo del flauros y la levitacion de los objetos. 
- Flauros center: partir de vectores de posicion local crea vertices, los une renderizando caras de un octaedro, creando un mapa Uv's y aplicando una textura custom.
- Flauros piramid: Crea vectores de posicion local, uniendolos creando caras formando un tetraedro perfecto, creando un mapa Uv's y aplicando una textura custom.
- Quit Manager: Reinicia la escena.

ShaderGraph y Cg/HLSL:

- Bottle: Por medio de una textura agrega un Fresnel de brillo interno. -Contiene Version Cg/HLSL y Shadergraph
- Glass: Añade un Fresnel a una transparencia creando un efecto como cristal. -Contiene Version Cg/HLSL y Shadergraph
- Liquid: Por medio de un calculo se genera una textura que da aparencia de liquido contnido en una forma, con difusion de 3 colores perzonalizables. -Contiene Version Cg/HLSL y Shadergraph

Externos:
- LiquidEffect by Minions Art.
- Script Liquid by Minions Art.
