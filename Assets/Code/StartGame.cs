using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    public void GameStart()
    {
        UpdateScore.score = 0;
        SceneManager.LoadScene("Nick's Scene");
    }

    public void LoadLevel3()
    {
        UpdateScore.score = 0;
        SceneManager.LoadScene("Aditya Scene");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
