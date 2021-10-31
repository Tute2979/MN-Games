using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    float tiempo = 0.3f;
    public GameObject Dona;



    void Update()
    {
        if (Time.time > tiempo)
        {
            tiempo = Time.time + 0.3f;
            Instantiate(Dona, new Vector3(Random.Range(18.8f, 63.79f), 13f, 0f), transform.rotation);
        }
    }



}
