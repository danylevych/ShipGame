using UnityEngine;
using UnityEngine.UI;


// +=========================================+
// |                                         |
// |   This script set the best and current  |
// |       score into the GameOver scene.    |
// |                                         |
// +=========================================+

public class SetScoreManager : MonoBehaviour
{
    [SerializeField] private Text score;
    [SerializeField] private Text bestScore;

    void Start()
    {
        score.text = "SCORE: " + PlayerPrefs.GetInt("score", 0).ToString("0");
        bestScore.text = "BEST SCORE: " + PlayerPrefs.GetInt("bestScore", 0).ToString("0");
    }
}
