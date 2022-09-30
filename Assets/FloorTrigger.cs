using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrigger : MonoBehaviour
{
    public bool hasBeenPlayed = false;
    public GameObject text;

  
    private void OnTriggerEnter(Collider obj){
        // code for triggering text box
        if(obj.gameObject.CompareTag("Player") && hasBeenPlayed == false){
            text.SetActive(true);
            hasBeenPlayed = true;
        }
    }

    private void OnTriggerExit(Collider obj){
        if(obj.gameObject.CompareTag("Player")){
            text.SetActive(false);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
