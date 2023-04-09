using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// +=========================================+
// |                                         |
// |   This script checks the target's HP    |
// |                                         |
// +=========================================+

public class HPManager : MonoBehaviour
{
    public static HPManager instance;
    
    [SerializeField] private Text hpText;
    [SerializeField] private AudioSource gameOver;

    private int hp = 100;
    private string typeHP = "█";

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        hp = 100;
        SetHPIntoLabel();
    }

    public void AddHP()
    {
        if (hp != 100)
        {
            hp += 10;
        }

        SetHPIntoLabel();
    }

    public void DelHP()
    {
        if (hp != 0)
        {
            hp -= 10;
        }

        if (hp == 0)
        {
            gameOver.Play();
            ScoreManager.instance.SaveScors();
            SceneManager.LoadScene("EndGame");
        }

        SetHPIntoLabel();
    }

    private void SetHPIntoLabel()
    {
        hpText.text = "";
        for (int i = 0; i < hp; i += 10)
        {
            hpText.text += typeHP;
        }
    }
}
