using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private GameObject explosionPref;


    private void Start()
    {
        health = 100;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameObject e = Instantiate(explosionPref, gameObject.transform.position, Quaternion.identity);

            Destroy(gameObject);
            Destroy(e, 0.25f);
        }
    }
}
