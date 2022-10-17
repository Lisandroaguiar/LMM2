using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadBoss : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float velocidad;
    [SerializeField] private float magnitud;
    [SerializeField] private float tiempoDeVida;
    private Transform jefe;
    private Transform jugador;

    // Update is called once per frame
    void Start()
    {
        jefe = GameObject.FindGameObjectWithTag("miniBoss").GetComponent<Transform>();
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if (jugador.position.x > jefe.position.x)
        {
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);
        }
        else if (jugador.position.x < jefe.position.x)
        {
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);
        }
        gameObject.GetComponent<Animator>().SetBool("Girar", true);
        Destroy(gameObject, tiempoDeVida);

    }
    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.CompareTag("Player"))
        { colision.GetComponent<ControladorJugador>().TomarMagnitud(magnitud); }

    }
}