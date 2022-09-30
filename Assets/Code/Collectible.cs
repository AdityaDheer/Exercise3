using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioSource collectSound;
    public bool wasPickedUp = false; //code that will hide the collectible upon being picked up

    void OnTriggerEnter(Collider obj)
    {
        collectSound.Play();
        Destroy(gameObject);
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
