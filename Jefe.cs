using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Jefe : MonoBehaviour
{
    private Animator animator;

    public Rigidbody2D rb2D;

    public Transform jugador;

    private bool mirandoDerecha = true;

    [SerializeField] private float vida;

    [SerializeField] private Transform controladorAtaque;

    [SerializeField] private float radioAtaque;

    [SerializeField] private float magnitudAtaque;

    public float cronometro;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);
        if (vida <= 0)
        {
            cronometro += 1 * Time.deltaTime;

            if (cronometro > 2.5)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
        }


    }
    // Update is called once per frame

    public void TomarMagnitud(float magnitud)
    {

        vida -= magnitud;
        if (vida > 1)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Damage");
        }
        else if (vida <= 0)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Muerte");
        }

    }

    private void Muerte()
    {//Destroy(gameObject);

    }

    public void MirarJugador()
    {
        if ((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }

    }
    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);
        foreach (Collider2D colision in objetos)
        {
            if (colision.CompareTag("Player"))
            {
                colision.GetComponent<ControladorJugador>().TomarMagnitud(magnitudAtaque);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }
}
