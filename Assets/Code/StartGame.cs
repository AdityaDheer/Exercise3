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
        SceneManager.LoadScene("City Scene");
    }

    public void LoadLevel3()
    {
        UpdateScore.score = 0;
        SceneManager.LoadScene("Aditya Scene");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Game Credits");
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void LoadHome() {
        SceneManager.LoadScene("Title Scene");
    }
}
