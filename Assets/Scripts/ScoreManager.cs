using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    public float scoreCount;
    public float highScoreCount;

    public float scorePerSecond;

    public bool scoreIncreasing;

    public bool shouldDouble;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += scorePerSecond * Time.deltaTime;
        }
        
        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "High score: " + Mathf.Round(highScoreCount);
    }

    public void AddScore(int scoreToAdd)
    {
        scoreCount += scoreToAdd;

        if (shouldDouble)
        {
            scoreToAdd = scoreToAdd * 2;
        }
    }
}
