using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 2f;


    public GameObject player;
    public Text interactuar;
    public GameObject candadoAbierto;
    public GameObject candadoCerrado;
    public int requisito;


    private void Start()
    {
        candadoAbierto.SetActive(false);
    }
    void Update()
    {

        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (ScoreManager.diamantes >= requisito)
        {
            candadoCerrado.SetActive(false);
            candadoAbierto.SetActive(true);
            if (distance <= 1f)
        {
            interactuar.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    LoadNextLevel();
                }
        }
        }


    }

    public void LoadNextLevel()
    {
        ScoreManager.puntuacionFinal += TimeManager.x;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
