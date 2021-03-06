using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public int diamondValue = 1;
    public Text vidas;
    public Text contadorMuertes;

    public float runSpeed = 40f;
    public static int muertes = 0;
    readonly int vidaTotal = 5;
    int vidaActual;
    float horizontalMove = 0f;
    bool jump;
    float damageCooldown = 0f;
    SpriteRenderer playerColor;

    public float jumpBufferLenght = .1f;
    private float jumpBufferCount;


    private void Start()
    {
        vidaActual = vidaTotal;
        playerColor = gameObject.GetComponent<SpriteRenderer>();
        contadorMuertes.text = "Muertes: " + muertes.ToString();
    }
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


        //manage jump buffer
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCount = jumpBufferLenght;
        }
        else
        {
            jumpBufferCount -= Time.deltaTime;
        }

        if (jumpBufferCount >= 0)
        {
            jump = true;
            animator.SetBool("jumping", true);
            jumpBufferCount = 0;
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        playerColor.color = Color.Lerp(playerColor.color, Color.white, Time.deltaTime / 0.2f);

    }


    public void OnLanding()
    {
        jump = false;
        animator.SetBool("jumping", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("diamantes"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("salame"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("salame") & Time.time >= damageCooldown)
        {
            playerColor.color = new Color(2, 0, 0);
            vidaActual--;
            FindObjectOfType<AudioManager>().Play("Hurt");
            vidas.text = "Vidas: "+vidaActual.ToString();
            damageCooldown = Time.time + 0.3f;
            if (vidaActual < 1)
            {
                FindObjectOfType<AudioManager>().Play("Death");
                muertes++;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (collision.transform.CompareTag("enemy") & Time.time >= damageCooldown)
        {
            playerColor.color = new Color(2, 0, 0);
            vidaActual--;
            FindObjectOfType<AudioManager>().Play("Hurt");
            vidas.text = "Vidas: " + vidaActual.ToString();
            damageCooldown = Time.time + 0.3f;
            if (vidaActual < 1)
            {
                FindObjectOfType<AudioManager>().Play("Death");
                muertes++;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (collision.transform.CompareTag("vacio"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
