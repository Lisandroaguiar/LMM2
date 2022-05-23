Cara ca;
ojos o;
click c;
garabato g;
garabato h;
garabato i;

boolean clickee;
boolean clickee5;
boolean clickee10;
int contador=0;
void setup() {
  size(800, 800);
  background(#72ddaa);

  
 
  ca = new Cara();
  o = new ojos();
  c = new click();
  g = new garabato();
   h = new garabato();
    i = new garabato();
}
void draw() { if (contador>=5){clickee5=true;}
if (contador>=10){clickee10=true;}
  background(#72ddaa);
  fill(255);
  circle(width/2, height/3, 380);
  o.dibujar();
  ca.dibujar();
  c.cambio();
  if (clickee==true){
  g.actualizar();
  g.dibujar(400,400);}
  
  if (clickee5==true){
  h.actualizar();
  h.dibujar(400,100);}
  
  if (clickee10==true){
  i.actualizar();
  i.dibujar(400,300);}
  
  println(contador);
}
void mouseClicked() {
  ca.cambios();
  o.cambios();
  clickee=true;
  contador++;
  
}
//{}
