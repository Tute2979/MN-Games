using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manzana : MonoBehaviour
{

    public int manzanaValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScoreManzana(manzanaValue);
            FindObjectOfType<AudioManager>().Play("Coin");
        }
    }
}