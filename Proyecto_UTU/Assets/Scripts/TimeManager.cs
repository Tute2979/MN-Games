using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public Image tiempo;
    public Text text;
    public float x = 60;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        x -= Time.deltaTime;
        
        if (x > 0)
        {
            text.text = "Tiempo: " + Mathf.Round(x).ToString();
            tiempo.fillAmount = x / 180;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}