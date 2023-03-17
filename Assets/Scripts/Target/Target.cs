using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private GameObject explosionPref;
    private float timeOfUpdate = 1.5f;
    private float timeLast = 0f;
    private int countOfScale = 0;

    private void Start()
    {
        health = 100;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameObject e = Instantiate(explosionPref, gameObject.transform.position, explosionPref.transform.rotation);

            Destroy(gameObject);
            Destroy(e, 0.25f);
        }
    }

    private void Update()
    {
        bool canSmoll = true;

        timeLast += Time.deltaTime;

        if (timeLast < timeOfUpdate)
        {
            transform.localScale += new Vector3(1f, 1f, 1f) * 0.1f;
            canSmoll = false;
            countOfScale++;
        }

        if (canSmoll && countOfScale != 0)
        {
            transform.localScale -= new Vector3(1f, 1f, 1f) * 0.1f;
            countOfScale--;
        }
    }


    private void RotateTarget(Transform from, Transform where)
    {
        Debug.Log("Rot");
        gameObject.transform.position = Vector3.Lerp(from.position, where.position, 0.5f);
        gameObject.transform.localScale = where.localScale;

        //gameObject.transform.position = Vector3.Lerp(where.position, from.position, 0.5f);
        //gameObject.transform.localScale = from.localScale;
    }
}
