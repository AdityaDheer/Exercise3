using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
       sentences = new Queue<string>(); 
    }

    public void StartDialogue(Dialogue dialogue){

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    /*
    void Update(){
        if(Input.GetKeyDown(KeyCode.X)){
            DisplayNextSentence();
        }
    }
    */

    public void DisplayNextSentence(){

        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        Debug.Log(sentence);
    }

    void EndDialogue(){
        Debug.Log("End of conversation.");
    }

    

}
