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
    private Vector3 normaltScale;
    private Vector3 endScale;
    private Vector3 startTargetPos;
    private Vector3 endTargetPos;

    private bool canScale = true;



    private void Start()
    {
        health = 100;

        normaltScale = gameObject.transform.localScale;
        endScale = gameObject.transform.localScale * 1.5f;
        startTargetPos = gameObject.transform.position;
        endTargetPos = gameObject.transform.position;
        endTargetPos.z -= 10;

        gameObject.transform.localScale = new Vector3(0f, 0f, 0f);

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
        if (canScale)
        {
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, endScale, Time.deltaTime * 80);
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endTargetPos, Time.deltaTime * speedHint);

            if (gameObject.transform.localScale.x >= endScale.x && gameObject.transform.position.x >= endTargetPos.x)
            {
                canScale = false;
            }
        }
        else
        {
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, normaltScale, Time.deltaTime * 100);
            gameObject.transform.position = Vector3.Lerp(endTargetPos, startTargetPos, Time.deltaTime * speedHint);
        }

        hint.transform.localScale = Vector3.Lerp(hint.transform.localScale, hintPref.transform.localScale, Time.deltaTime * speedHint);

        hint.transform.position = Vector3.Lerp(hint.transform.position, startTargetPos, Time.deltaTime * speedHint);
    }
}
