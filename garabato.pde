class garabato {
  PGraphics ga;
  float x, y, dir, vel, angulo, dista;
  garabato() {
    ga = createGraphics(width, height);
    ga.beginDraw();
    ga.endDraw();
    x = width/2;
    y = height/2;
  }
  void actualizar() {
    dir += random(90, 100);
    vel = 1;
    dista = random(2, 10);
    x = x+dista*cos(dir*2);
    y = y+dista*sin(dir*2);
  }
  void dibujar(float a, float b) {    
    ga.beginDraw();
    ga.fill(0);
    ga.circle(x, y, 5);
    ga.endDraw();
    push();
    
    
      
      image(ga, a, b);
    
    pop();
  }
}
