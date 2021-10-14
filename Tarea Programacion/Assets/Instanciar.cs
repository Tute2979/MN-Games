using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instanciar : MonoBehaviour
{

    public Text score;
    float tiempo = 1f;
    public GameObject piedra;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > tiempo)
        {
            Debug.Log(tiempo);
            tiempo = Time.time + 1;
            Instantiate(piedra, new Vector3(Random.Range(0, 10), 5f, 0f), transform.rotation);
        }

        score.text = "Puntaje: " + Collision.puntaje;
    }
}
