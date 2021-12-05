using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject Prompt;

    public static bool IsTalking;
    bool IsInRange;

    public void DisplayNextScene() => FindObjectOfType<DialogueManager>().DisplayNextSentence();

    public void TriggerDialogue() => FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    private void Update()
    {
        if (IsInRange)
        {
            Prompt.SetActive(true);
            if (Input.GetButtonDown("InteractButton"))
            {
                if (!IsTalking)
                {
                    TriggerDialogue();
                    IsTalking = true;
                }
                else if (IsTalking)
                {
                    DisplayNextScene();
                }
            }
        }
        else if (!IsInRange)
        {
            Prompt.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsInRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsInRange = false;
    }
}
