using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public static int score = 0;
    public GameObject scoreText;

    void OnTriggerEnter(Collider other)
    {
        scoreText.GetComponent<Text>().text = score.ToString();
    }
}
