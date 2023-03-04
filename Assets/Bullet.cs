using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;

    [SerializeField]
    private Rigidbody bulletPref;
    [SerializeField]
    private Camera camera;

    private void Awake()
    {
        if (!camera) camera = Camera.main;
    }

    private void Update()
    {

        Vector3 cameraPos = camera.transform.position;
        float distance = camera.farClipPlane;

        cameraPos.z += distance;

        int y = camera.pixelHeight / 2;
        int x = camera.pixelWidth / 2;


        transform.Translate((cameraPos + -transform.position) * speed * Time.deltaTime);

        if (transform.localScale.x >= 0f && transform.localScale.y >= 0f && transform.localScale.z >= 0f)
        {
            transform.localScale += new Vector3(-0.2f, -0.2f, -0.2f) * Time.deltaTime;
        }
    }
}
