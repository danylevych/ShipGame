using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField]
    private Text scoreText;
    private int score = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void AddScore()
    {
        score += 100;
        scoreText.text = "SCORE: " + score.ToString();
    }
}
