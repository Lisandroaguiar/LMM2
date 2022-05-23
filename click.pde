class click {
  
  PImage m1, m2;
  click() {
    m1 = loadImage("mano.png");
    m2 = loadImage("mano2.png");
   
  }
  void cambio() {
    push();
    if (mousePressed == false) {
      tint(#FFE5C8, 220);
      image(m1, mouseX-60, mouseY+80);
      noCursor();
    } else if (mousePressed == true) {
      tint(#FFE5C8, 220);
      image(m2, mouseX, mouseY);
      noCursor();
    }
    pop();
    
   
  }
}
