using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int speedHint;
    [SerializeField] private GameObject hintPref;
    [SerializeField] private GameObject explosionPref;

    private GameObject hint;
    private Vector3 startTargetPos;


    private void Start()
    {
        health = 100;

        startTargetPos = gameObject.transform.position;
        hint = Instantiate(hintPref, new Vector3(0, 0, -15), Quaternion.identity);
        hint.transform.localScale = new Vector3(20f, 20f, 20f);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameObject e = Instantiate(explosionPref, gameObject.transform.position, explosionPref.transform.rotation);

            Destroy(gameObject);
            Destroy(hint);
            Destroy(e, 0.25f);
        }
    }

    private void Update()
    {
        hint.transform.localScale = Vector3.Lerp(hint.transform.localScale, hintPref.transform.localScale, Time.deltaTime * speedHint);

        hint.transform.position = Vector3.Lerp(hint.transform.position, startTargetPos, Time.deltaTime * speedHint);
    }
}
