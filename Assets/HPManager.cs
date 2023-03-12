﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

            PlayerPrefs.SetInt("score", ScoreManager.instance.GetScore());
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
