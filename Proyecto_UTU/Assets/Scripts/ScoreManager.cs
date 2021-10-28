using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public Text text;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        if (instance == null)
        {
            instance = this;
        }
        score = 0;
    }



    public void ChangeScore(int diamondValue)
    {
        score += diamondValue;
        text.text = score.ToString() + "/22";
    }
}
