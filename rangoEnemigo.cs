using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangoEnemigo : MonoBehaviour
{
    public Animator ani;
    public ControladorEnemigo enemigo;
    public ControladorJugador jugador;
    

    void OnTriggerEnter2D (Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            ani.SetBool("caminar",false);
            ani.SetBool("ataqueEnemigo",true);
            enemigo.atacando=true;
            
            GetComponent<BoxCollider2D>().enabled=false;
            
           
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
