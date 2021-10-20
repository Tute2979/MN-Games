using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{

    public GameObject player;
    public Text interactuar;
    public Dialogue dialogue;


    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= 3f)
        {
            interactuar.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                TriggerDialogue();
            }
        }
        else
        {
            interactuar.enabled = false;
            FindObjectOfType<DialogueManager>().EndDialogue();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }



    
}
