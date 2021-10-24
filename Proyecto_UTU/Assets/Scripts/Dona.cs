using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dona : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "arrow")
        {
            Destroy(this.gameObject);
        }
    }
}
