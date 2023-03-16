using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text bestScoreText;

    private int score = 0;
    private int bestScore = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("bestScore");

        scoreText.text = "SCORE: " + score.ToString();
        bestScoreText.text = "BEST SCORE: " + bestScore.ToString();
    }

    public void AddScore()
    {
        score += 100;
        if (score >= bestScore)
        {
            bestScore = score;
        }
        scoreText.text = "SCORE: " + score.ToString();
        bestScoreText.text = "BEST SCORE: " + bestScore.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    public int GetBestScore()
    {
        return bestScore;
    }

    public void SaveScors()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("bestScore", bestScore);
    }
}
