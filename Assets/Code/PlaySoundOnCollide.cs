using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollide : MonoBehaviour
{
    public AudioSource triggeredSound;
    //[SerializeField] public int numberOfTimes = 1;

    void OnTriggerEnter(Collider other)
    {
        //triggeredSound.Play();
        triggeredSound.enabled = true;
        //numberOfTimes -= 1;
        //if (numberOfTimes == 0) {}
        //Destroy(gameObject);
    }
}
