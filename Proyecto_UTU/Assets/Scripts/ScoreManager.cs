using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public Text cantDiamantes;
    public Text cantManzanas;
    public Text cantBananas;
    public Text cantPi�as;
    public static int diamantes;
    public static int manzanas;
    public static int bananas;
    public static int pi�as;

    // Start is called before the first frame update
    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        diamantes = 0;
        manzanas = 0;
        bananas = 0;
        pi�as = 0;
    }



    public void ChangeScoreDiamante(int diamondValue)
    {
        diamantes += diamondValue;
        cantDiamantes.text = diamantes.ToString() + "/22";
    }

    public void ChangeScoreManzana(int manzanaValue)
    {
        manzanas += manzanaValue;
        cantManzanas.text = manzanas.ToString() + "/9";
    }

    public void ChangeScoreBanana(int bananaValue)
    {
        bananas += bananaValue;
        cantBananas.text = bananas.ToString() + "/8";
    }

    public void ChangeScorePi�a(int pi�aValue)
    {
        pi�as += pi�aValue;
        cantPi�as.text = pi�as.ToString() + "/8";
    }
}
