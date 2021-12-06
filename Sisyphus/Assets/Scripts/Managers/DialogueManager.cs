using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [Header("DialogueReferences")]
    public GameObject TextBox;
    public TMP_Text npcNameText;
    public TMP_Text dialogueText;

    [Space]

    [Header("References")]
    public Animator anim;
    
    [Header("Sentences")]
    private Queue<string> sentences;


    //Creates new list of dialogue
    private void Start() => sentences = new Queue<string>();

    //Starts dialogue, enables textbox
    public void StartDialogue(Dialogue dialogue)
    {
        anim.SetBool("Open", true);
        Time.timeScale = 0;
        TextBox.SetActive(true);
        npcNameText.text = dialogue.npcName;
        npcNameText.color = dialogue.nameColor;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    //Displays the next sentence in queue
    public void DisplayNextSentence()
    {
        if(sentences.Count < 1)
        {
            EndDialogue();
            return;
        }

        string CurrentSentence = sentences.Dequeue();
        dialogueText.text = CurrentSentence;
    }

    //Ends the dialogue and disables the textbox
    public void EndDialogue()
    {
        Time.timeScale = 1;
        TextBox.SetActive(false);
        PlayerMovement.currentState = PlayerMovement.PlayerStates.NotTalking;
        Interactable.IsTalking = false;
        anim.SetBool("Open", false);
        if (Interactable.TriggersFight)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            return;
        }
    }
}
