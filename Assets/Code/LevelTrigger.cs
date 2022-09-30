using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    //int score = 0;
    //[SerializeField] int scoreToLeave = 0;
    //[SerializeField] public GameObject denialText;
    [SerializeField] string levelToLoad;

    void OnTriggerEnter(Collider other)
    {
        //int score = other.score;
        //denialText = other

        //if (score < scoreToLeave)
        //{
        //    denialText.enabled = true;
        //}

        //else 
        //{
            SceneManager.LoadScene (sceneName:levelToLoad);
        //}
    }
}
