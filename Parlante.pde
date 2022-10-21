class Parlante {
  FCircle notas;
  float x, y;
  float ancho = 70;
  float alto =70;
  float velocidad = 500;
  float anguloVel = 2;
  float angulo;
  PImage nota1, nota2, nota3;
  int PUERTO_IN_OSC = 12345;
  int PUERTO_OUT_OSC = 12346;
  String IP = "127.0.0.1";

  Receptor receptor;

  Emisor emisor;



  PuntoLocal p;
  Parlante( float x_, float y_ ) {
    x=x_;
    y= y_;
    angulo = radians (40);
    notas = new FCircle(90);
    setupOSC(PUERTO_IN_OSC, PUERTO_OUT_OSC, IP);
    p = new PuntoLocal(1001, notas.getX(), notas.getY());
    emisor = new Emisor();
    emisor.addPunto(p);

    receptor = new Receptor();
    receptor.setPuntosLocales(emisor.puntosLocales);
  }

  void dibujar () {
    pushMatrix();
    nota1 = loadImage("imagenes/notas.png");
    nota2 = loadImage("imagenes/notas.png");
    nota3 = loadImage("imagenes/notas.png");

    rect(x, y, ancho, alto);
    popMatrix();
  }

  void dibujarNotas( FWorld mundo) {

    

    float vx = velocidad * cos (angulo);
    float vy = velocidad * sin (angulo);

    notas.setPosition( x+50, y+10 );
    notas.setGrabbable(true);
    notas.setVelocity (vx, vy);

    //para despues detectar las coliciones
    notas.setName("notas");
    notas.setDensity(0.03);
    if (random(2)<1) {
      notas.attachImage(nota1);
    } else if (random(2)>1) {
      notas.attachImage(nota2);
    } else {
      notas.attachImage(nota3);
    }
    mundo.add(notas);
  }

  void oportunidades(SoundFile audio) {
    ArrayList <FBody> cuerpos = mundo.getBodies();

    for (FBody este : cuerpos) {
      String nombre = este.getName();
      if (nombre != null && nombre.equals("notas") && este.getY() > height) {
       
          
            opo--;
            mundo.remove(este);
            audio.play();
          
        
      }
    }
  }
  void mover() {float x=constrain(notas.getX(),0, width);
  float y=constrain(notas.getY(),0, height);
    receptor.actualizar(mensajes);
    receptor.dibujarZonasRemotas(width, height);
    p.actualizarPosicion(x, y);

    notas.addImpulse(p.getMovX(), p.getMovY() );

    p.actualizarPosicion(x, y); // mi punto local actualiza su posición en funciób del FCircle c

    notas.addImpulse(p.getMovX()*5, p.getMovY() *5); // le doy un impulso al FCircle c en la dirección de movimiento del punto p

    emisor.actualizar();
    emisor.dibujar();
  }
}
