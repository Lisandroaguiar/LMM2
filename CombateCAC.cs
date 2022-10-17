using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateCAC : MonoBehaviour
{
    public float cronometro;
    [SerializeField] public Transform controladorAtaque;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float magnitudGolpe;

    public Animator animator;

    public AudioClip Sespada;

    private void Update()
    {
        cronometro += 1 * Time.deltaTime;

        if (Input.GetKeyDown("f") && cronometro >= 0.5)
        {
            AudioManager.Instance.ReproducirSonido(Sespada);
            animator.SetBool("atacando", true);
            cronometro = 0;
        }
        else
        {
            animator.SetBool("atacando", false);
        }
    }


    private void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioGolpe);
        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("enemigo"))
            {
                colisionador.transform.GetComponent<ControladorEnemigo>().TomarMagnitud(magnitudGolpe);
            }
            if (colisionador.CompareTag("miniBoss"))
            {
                colisionador.transform.GetComponent<Jefe>().TomarMagnitud(magnitudGolpe);
            }

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioGolpe);
    }
}
