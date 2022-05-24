class Cara {
  color [] c =
    {
    #2D221E, 
    #3C2E28, 
    #4B3932, 
    #b1a0cb, 
    #5A453C, 
    #695046, 
    #785C50, 
    #ed8ab4, 
    #87675A, 
    #967264, 
    #A57E6E, 
    #f2e21e, 
    #B48A78, 
    #C39582, 
    #D2A18C, 
    #E1AC96, 
    #F0B8A0, 
    #8893eb, 
    #FFC3AA, 
    #ec9a3e, 
    #FFCEB4, 
    #FFDABE, 
    #FFE5C8, 
  };
  int queColor = 0;
  int click, i;
  float x, y, d;
  PImage [] tipo = new PImage[7];

  Cara() {

    imageMode(CENTER);
    rectMode(CENTER);
    for (int i = 0; i < tipo.length; i++) {
      tipo [i] = loadImage("tipo"+i+".png");
    }
    click = 0;
    i = 0;
  }

  void cambios() { 
    x = width/2;
    y = height/3;
    d = 400;

    if (queColor > 20) {
      queColor = 0;
    }
    if (dist(mouseX, mouseY, x, y) < d/2 || mouseX > 349 && mouseX < 461 && mouseY > 480 && mouseY < 630 || mouseX > 150 && mouseX < 650 && mouseY > 630 && mouseY < 830) {
      queColor++;
      click++;
      auch.play();
    }
    if (dist(mouseX, mouseY, 310, 280) < 100/2 || dist(mouseX, mouseY, 495, 280) < 100) {
      queColor =+0;// como hago para q deje de sumarr AAHHH
    }
    if (click > 5) {
      i = int(random(6));
    }
    if (click > 7) {
      i = int(random(6));
    }
    if (click > 9) {
      i = int(random(6));
    }
    if (click > 12) {
      i = int(random(6));
    }
    if (click > 16) {
      i = int(random(6));
    }
    if (click > 20) {
      i = int(random(6));
      auch.stop();
      sfondo.stop();
      llanto.play();
      //queColor = 20;
      //llanto.play();
    }
  }
  void dibujar() {
    //circle(x, y, d);
    //rect(402, 555, 118, 150);
    //rect(400, 730, 500,200);
    //fill(c[queColor]);
    push();
    tint(c[queColor]);
    image(tipo[i], width/2, height/2, 600, 720);
    pop();
  }
}
