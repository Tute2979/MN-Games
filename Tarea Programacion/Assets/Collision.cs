using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{

    public static int puntaje;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            Destroy(this.gameObject);
        }
        if (collision.transform.tag == "ball")
        {
            Destroy(this.gameObject);
        }
        if (collision.transform.tag == "rock")
        {
            Destroy(this.gameObject);
            puntaje += 10;
        }
    }
}
