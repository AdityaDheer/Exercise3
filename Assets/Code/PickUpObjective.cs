using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUpObjective : MonoBehaviour
{
    public AudioSource pickupSound;

    void OnTriggerEnter(Collider other)
    {
        pickupSound.Play();
        UpdateScore.score ++;
        Destroy(gameObject);
        if (SceneManager.GetActiveScene().name == "Aditya Scene") {
            if (UpdateScore.score == 1) {
                SceneManager.LoadScene("Game Over Scene");
            }
        }
    }
}
