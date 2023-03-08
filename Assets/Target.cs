using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private int health;

    private void Start()
    {
        health = 100;
    }

    public void HelthDown()
    {
        health -= 10;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
