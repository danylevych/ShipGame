using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text score;

    void Start()
    {
        score.text = "SCORE: " + PlayerPrefs.GetInt("score", 0).ToString("0");
    }
}
