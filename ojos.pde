class ojos {
  color [] colorOjos =
    {
    #287233,
    #ffb5e8,
    #b28dff,
    #85e3ff,
    #e7ffac,
    #3B83BD, 
    #C29B61,
    #ffabab,
    #4B3621,
    #6eb5ff,
    #804000,
    #6ac0e2
  };
  int queColorOjos = 0;
  int click;
  ojos() {
    click = 0;
  }
  void cambios() {
    if (queColorOjos>11) {
      queColorOjos=0;
    }
    if (dist(mouseX, mouseY, 310, 280) < 100/2 || dist(mouseX, mouseY, 495, 280) < 100) {
      queColorOjos++;
      click++;
    }
    if (click > 11){
      queColorOjos = 11;
    }
  }
  void dibujar() {
    push();
    //fill(0);
    fill(colorOjos[queColorOjos]);
    circle(310, 280, 80);
    circle(495, 280, 80);
    fill(0);
    circle(310, 280, 50);
    circle(495, 280, 50);
    
    fill(255);
    circle(300, 270, 20);
    circle(485, 270, 20);
    pop();
  }
}
