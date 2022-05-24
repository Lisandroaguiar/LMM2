import processing.sound.*;
SoundFile auch, llanto, sfondo;

Cara ca;
ojos o;
click c;
garabato g;
garabato h;
garabato i;
garabato j;
garabato k;
garabato l;
garabato q;
garabato w;
garabato e;
garabato r;
garabato t;
boolean clickee;
boolean clickee5;
boolean clickee10;

boolean clickee15;
boolean clickee20;
boolean clickee25;


int contador=0;
PImage fondo;
void setup() {
  size(800, 800);
  background(#72ddaa);

  fondo = loadImage("espejo.png");

  ca = new Cara();
  o = new ojos();
  c = new click();
  g = new garabato();
  h = new garabato();
  i = new garabato();
  j = new garabato();
  k = new garabato();
  l = new garabato();
    q = new garabato();
  w = new garabato();
  e = new garabato();
  r = new garabato();
  t = new garabato();
  auch = new SoundFile(this, "auch2.wav");
  llanto = new SoundFile(this, "llanto.mp3");
  sfondo = new SoundFile(this, "fondo.wav");

  sfondo.amp(0.2);
  sfondo.loop();
}
void draw() { 
  if (contador>=5) {
    clickee5=true;
  }
  if (contador>=10) {
    clickee10=true;
  }
  
    if (contador>=15) {
    clickee15=true;
  }
  if (contador>=20) {
    clickee20=true;
  }
  if (contador>=25) {
    clickee25=true;
  }
  background(#72ddaa);
  image(fondo, width/2, height/2, width+300, height+60);
  noStroke();
  fill(255);
  circle(width/2, height/3, 300);
  o.dibujar();
  ca.dibujar();
  c.cambio();
  if (clickee==true) {
    g.actualizar();
    g.dibujar(400, 400);
  }

  if (clickee5==true) {

    h.actualizar();
    h.dibujar(400, 100);
  }

  if (clickee10==true) {
    i.actualizar();
    i.dibujar(400, 300);
  }
  
    if (clickee15==true) {
    j.actualizar();
    j.dibujar(400, 350);
       q.actualizar();
    q.dibujar(450, 350);
       w.actualizar();
    w.dibujar(350, 350);
  }

  if (clickee20==true) {

    k.actualizar();
    k.dibujar(400, 150);
        e.actualizar();
    e.dibujar(450, 150);
        r.actualizar();
    r.dibujar(350, 150);
  }

  if (clickee25==true) {
    l.actualizar();
    l.dibujar(400, 450);
    t.actualizar();
    t.dibujar(350, 450);
  }
  println(contador);
}
void mouseClicked() {
  ca.cambios();
  o.cambios();
  clickee=true;
  contador++;
}
