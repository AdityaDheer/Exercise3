using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider obj){
        // code for triggering text box
        if(obj.gameObject.CompareTag("Player")){
            text.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider obj){
        if(obj.gameObject.CompareTag("Player")){
            text.SetActive(false);
        }
    }
}
