using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public static HPManager instance;

    [SerializeField]
    private Text hpText;

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
            Debug.Log("You lose");
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
