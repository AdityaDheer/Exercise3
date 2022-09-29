using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObjective : MonoBehaviour
{
    public GameObject scoreText;
    public int score = 0;
    public AudioSource pickupSound;

    void OnTriggerEnter(Collider other)
    {
        pickupSound.Play();
        score ++;
        scoreText.GetComponent<Text>().text = score.ToString();
    }
}
