using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    public bool isTriggered = false;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }
    
    void Update(){
        if(Input.GetKeyDown(KeyCode.X) && !isTriggered){
            TriggerDialogue();
            isTriggered = true;
        }
        else if(Input.GetKeyDown(KeyCode.X) && isTriggered){
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }
}
