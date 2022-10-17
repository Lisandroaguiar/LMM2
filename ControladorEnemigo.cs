using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEnemigo : MonoBehaviour
{
    [SerializeField] private float vida;

    public ControladorJugador cj;

    private Animator animator;
    public int rutina;
    public float cronometro;
    public float cronometro2;
    public Animator ani;
    public int direccion;
    public float speed_walk;
    public GameObject target;
    public bool atacando;

    public float rangoVision;
    public float rangoAtaque;
    public GameObject rango;
    public GameObject Hit;

    public AudioClip Sespada;

    private void Start()
    {
        animator = GetComponent<Animator>();
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }
    public void Final_Ani()
    {
        ani.SetBool("ataqueEnemigo", false);
        atacando = false;
        rango.GetComponent<BoxCollider2D>().enabled = true;


    }

    public void ColliderWeaponTrue()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = true;

    }

    public void ColliderWeaponFalse()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = false;

    }


    void Update()
    {
        Comportamiento();
        if(cj.Powerup){
             ani.SetBool("powerUp", true);
           ani.SetBool("ataqueEnemigo", false);
        }
     
  else if(!cj.Powerup){
             ani.SetBool("powerUp", false);
          
        }
    }
    public void TomarMagnitud(float magnitud)
    {

        vida -= magnitud;
        if (vida > 0)
        {

            gameObject.GetComponent<Animator>().SetTrigger("Damage");


        }


        else if (vida <= 0)
        {
            Muerte();

        }
    }

    

    private void Muerte()
    {
        gameObject.GetComponent<Animator>().SetBool("muerteEnemigo", true);
    }

    public void Comportamiento()
    {
        if (Mathf.Abs(transform.position.x - target.transform.position.x) > rangoVision && !atacando)
        {

            cronometro += 1 * Time.deltaTime;

            if (cronometro >= 2)
            {

                rutina = Random.Range(0, 2);
                direccion = Random.Range(0, 2);
                cronometro = 0;
            }


            switch (rutina)

            {

                case 0:
                    ani.SetBool("caminar", false);
                    break;

                case 1:

                    switch (direccion)
                    {
                        case 0:
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            transform.Translate(Vector3.left * speed_walk * Time.deltaTime);
                            gameObject.GetComponent<SpriteRenderer>().flipX = true;
                            break;


                        case 1:
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                            gameObject.GetComponent<SpriteRenderer>().flipX = false;
                            break;

                    }

                    ani.SetBool("caminar", true);

                    break;


            }


        }
        else
        {
            if (Mathf.Abs(transform.position.x - target.transform.position.x) > rangoAtaque && !atacando)
            {
                if (transform.position.x < target.transform.position.x)
                {
                    transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    ani.SetBool("ataqueEnemigo", false);
                    ani.SetBool("caminar", true);
                }
                else
                {

                    transform.Translate(Vector3.left * speed_walk * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    ani.SetBool("ataqueEnemigo", false);
                    ani.SetBool("caminar", true);

                }
            }
            else
            {
                if (!atacando)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);

                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);


                }
                ani.SetBool("caminar", false);


            }
        }

    }
    private IEnumerator Pu()
    {
        speed_walk = 0;
        atacando = false;
        GetComponent<SpriteRenderer>().color = Color.yellow;
        //gameObject.GetComponent<Animator>().SetTrigger("quieto");
        yield return new WaitForSeconds(6);
        GetComponent<SpriteRenderer>().color = Color.white;
        speed_walk = 1;

    }



}



