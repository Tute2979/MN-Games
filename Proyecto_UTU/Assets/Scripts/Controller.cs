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
    bool jump = false;
    float damageCooldown = 0f;
    SpriteRenderer playerColor;


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


        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("jumping", true);
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        playerColor.color = Color.Lerp(playerColor.color, Color.white, Time.deltaTime / 0.2f);

    }


    public void OnLanding()
    {
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
            vidas.text = "Vidas: "+vidaActual.ToString();
            damageCooldown = Time.time + 0.3f;
            if (vidaActual < 1)
            {
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