using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piña : MonoBehaviour
{

    public int piñaValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScorePiña(piñaValue);
            FindObjectOfType<AudioManager>().Play("Coin");
        }
    }
}