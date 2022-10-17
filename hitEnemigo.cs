using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitEnemigo : MonoBehaviour
{
    [SerializeField] private float magnitudGolpe;
    public float cronometro;
    public AudioClip Sespada;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {

            cronometro += 1;
            if (cronometro >= 2)
            {
                AudioManager.Instance.ReproducirSonido(Sespada);
                coll.transform.GetComponent<ControladorJugador>().TomarMagnitud(magnitudGolpe);
                print("Damage");

                cronometro = 0;
            }
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
