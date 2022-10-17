using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ControladorJugador : MonoBehaviour
{
    public float vel;
    public float fuerzasalto;
    public int nromaxsalto;
    public LayerMask capasuelo;

    public float cronometroMuerte;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private int saltorestantes;

    private bool sepuedemover = true;
    public bool Powerup = false;

    public bool der = false;

    private Animator animator;

    bool canJump;
    bool muerteJugador;

    [SerializeField] public float vida;

    //-----vidas-------
    ControladorEnemigo enemigo;
    public Image Corazon;
    public int CantDeCorazon;
    public RectTransform PosicionPrimerCorazon;
    public Canvas MyCanvas;
    public int OffSet;

    //=====================Sonido=====================
    public AudioClip Scaminar;
    public AudioClip Ssaltar;
    public AudioClip Spu;

    private bool ActivarPowerup;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

        saltorestantes = nromaxsalto;

        Transform PosCorazon = PosicionPrimerCorazon;

        for (int i = 0; i < CantDeCorazon; i++)
        {
            Image NewCorazon = Instantiate(Corazon, PosCorazon.position, Quaternion.identity);
            NewCorazon.transform.parent = MyCanvas.transform;
            PosCorazon.position = new Vector2(PosCorazon.position.x + OffSet, PosCorazon.position.y);
        }
    }

    void Update()
    {
        movimiento();
        salto();
        
        

        if (vida <= 0)
        {
            Muerte();
            Destroy(Corazon);
        }

if(ActivarPowerup && Input.GetKeyDown(KeyCode.P))
{
    Powerup=true;
}
    }
    void movimiento()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");
        if (sepuedemover == true)
        {
            rb.velocity = new Vector2(inputMovimiento * vel, rb.velocity.y);

            if (inputMovimiento != 0f && !muerteJugador)
            {
                animator.SetBool("moviendo", true);
            }
            else
            {
                animator.SetBool("moviendo", false);
            }

            orientacion(inputMovimiento);
        }
    }
    bool Estauelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capasuelo);
        return raycastHit.collider != null;
    }
    void salto()
    {
        if (Estauelo())
        {
            saltorestantes = nromaxsalto;
        }
        if (Input.GetKeyDown(KeyCode.Space) && saltorestantes > 0 && !muerteJugador && sepuedemover)
        {
            animator.SetBool("saltando", true);
            saltorestantes--;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * fuerzasalto, ForceMode2D.Impulse);

        }
        else
        {
            animator.SetBool("saltando", false);

        }
    }
    void orientacion(float inputMovimiento)
    {

        if (der == false && inputMovimiento < 0 || der == true && inputMovimiento > 0)
        {
            der = !der;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
    private void Muerte()
    {
        animator.SetBool("murio", true);
        sepuedemover = false;
        cronometroMuerte += 1 * Time.deltaTime;
        if (cronometroMuerte > 2)
        {
            SceneManager.LoadScene(4);
        }
    }


    public void TomarMagnitud(float magnitud)
    {
        vida -= magnitud;
        StartCoroutine(PerderControl());

        if (magnitud == 20)
        {
            Destroy(MyCanvas.transform.GetChild(CantDeCorazon + 1).gameObject);
            CantDeCorazon -= 1;
        }

        if (vida <= 0)
        {
            Muerte();
            gameObject.GetComponent<Animator>().SetBool("murio", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PowerUp")
        {
            AudioManager.Instance.ReproducirSonido(Spu);
            Destroy(collision.gameObject);
            GetComponent<SpriteRenderer>().color = Color.blue;
            
                 
            
                vel = vel * 1.5f;
                ActivarPowerup = true;
               
            
            StartCoroutine(ResetPU());

        }
    }
    private IEnumerator PerderControl()
    {
        sepuedemover = false;
        GetComponent<SpriteRenderer>().color = Color.red;
        gameObject.GetComponent<Animator>().SetTrigger("Damage");
        yield return new WaitForSeconds(2);
        GetComponent<SpriteRenderer>().color = Color.white;
        sepuedemover = true;

    }
    private IEnumerator ResetPU()
    {
        yield return new WaitForSeconds(6);
        vel = 4;
        GetComponent<SpriteRenderer>().color = Color.white;
        Powerup=false;
        ActivarPowerup = false;
    }
}

