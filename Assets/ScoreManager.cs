using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    public int scoreCount;
    public static int highscoreCount;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highscoreCount = PlayerPrefs.GetInt("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreCount > highscoreCount) 
        {
            highscoreCount = scoreCount;
            PlayerPrefs.SetInt("HighScore", highscoreCount);
        }
        scoreText.text = "Score: " + scoreCount;
        highscoreText.text = "HighScore: " + highscoreCount;
    }
}
