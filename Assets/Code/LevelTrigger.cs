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
    //[SerializeField] float _x = 0;
    //[SerializeField] float _y = 0;
    //[SerializeField] float _z = 0;

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
        SceneManager.LoadSceneAsync(sceneName:levelToLoad);
        //}
        //other.transform.position = new Vector3(_x, _y, _z);
    }
}
