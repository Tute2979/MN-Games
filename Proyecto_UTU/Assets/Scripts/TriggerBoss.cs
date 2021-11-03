using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoss : MonoBehaviour
{
    public GameObject parca;
    public GameObject parcaNPC;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        parca.SetActive(true);
        parcaNPC.SetActive(false);
        Destroy(this.gameObject);
    }
}
