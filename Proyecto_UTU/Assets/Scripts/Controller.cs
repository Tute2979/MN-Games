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

    public float runSpeed = 40f;
    readonly int vidaTotal = 5;
    int vidaActual;
    float horizontalMove = 0f;
    bool jump = false;


    private void Start()
    {
        vidaActual = vidaTotal;
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
        if (collision.transform.CompareTag("salame"))
        {
            vidaActual--;
            vidas.text = "Vidas: "+vidaActual.ToString();
            if (vidaActual < 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
