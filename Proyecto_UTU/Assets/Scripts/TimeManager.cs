using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public Text text;
    public static float x = 180;
    // Start is called before the first frame update
    void Start()
    {
        x = 180;
    }

    // Update is called once per frame
    void Update()
    {
        x -= Time.deltaTime;
        
        if (x > 0)
        {
            text.text = "Tiempo: " + Mathf.Round(x).ToString();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}