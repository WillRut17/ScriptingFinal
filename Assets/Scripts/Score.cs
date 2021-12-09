using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static float score;
    public Text scoreText;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            float minutes = Mathf.FloorToInt(score / 60);
            float seconds = Mathf.FloorToInt(score % 60);

            scoreText.text = string.Format("Time Survived: {0:00}:{1:00}", minutes, seconds);
        }
    }
}
