using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 300f;

    private Vector3 startPos;
    private Vector3 target;
    private GameObject leftWing;
    private GameObject rightWing;

    private float offset;
    private float distance;
    private float startTime;
    

    private void Start()
    {
        leftWing = GameObject.Find("Left");
        rightWing = GameObject.Find("Right");

        startTime = Time.time;
        target = new Vector3(0, 0, Camera.main.farClipPlane);
        startPos = transform.position;
        distance = Vector3.Distance(transform.position, target);

        if (Vector3.Distance(transform.position, leftWing.transform.position) <= 1)
        {
            offset = -1;
        }
        else
        {
            offset = 1;
        }
    }

    private void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / distance;

        float x = Mathf.Lerp(startPos.x, target.x, fracJourney);
        float y = Mathf.Lerp(startPos.y, target.y, fracJourney);
        float z = Mathf.Lerp(startPos.z, target.z, fracJourney);

        transform.position = new Vector3(x + offset, y, z);
    }
}
