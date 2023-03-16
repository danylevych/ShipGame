using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text bestScore;

    void Start()
    {
        score.text = "SCORE: " + PlayerPrefs.GetInt("score", 0).ToString("0");
        bestScore.text = "BEST SCORE: " + PlayerPrefs.GetInt("bestScore", 0).ToString("0");
    }
}
