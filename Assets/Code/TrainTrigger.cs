using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainTrigger : MonoBehaviour
{

    public bool hasBeenPlayed = false;
    public GameObject text;
    public Animation animateTrain;
    public bool animationTriggered = false;
    public PlayerController Player;
    public string NextLevel;


    private void OnTriggerStay(Collider obj){
        Player.GetComponent<Rigidbody>().velocity=Vector3.zero;
    }
    
    private void OnTriggerEnter(Collider obj){
        // code for triggering text box
        if(obj.gameObject.CompareTag("Player") && hasBeenPlayed == false){
            Player.PlayerControlAllowed = false;
            Player.GetComponent<Rigidbody>().velocity=Vector3.zero;
            Player.transform.eulerAngles = new Vector3(0, 0, 0);
            hasBeenPlayed = true;
            StartCoroutine(trainTimer());
        }
    }

    private IEnumerator trainTimer(){
        text.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        text.SetActive(false);
        animateTrain.Play();
        
        yield return new WaitForSeconds(1.43f);
        SceneManager.LoadScene(NextLevel);
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
