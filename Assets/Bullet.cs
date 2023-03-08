using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject hitting;

    public float speed = 300f;

    private Vector3 startPos;
    private Vector3 target;

    private float offset;
    private float distance;
    private float startTime;
    

    private void Start()
    {
        // hitting = GetComponent<Animator>();

        GameObject leftWing = GameObject.Find("Left");
        GameObject rightWing = GameObject.Find("Right");

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
    //{
    //    Vector3 cameraPos = Camera.main.transform.position;
    //    float distance = Camera.main.farClipPlane;

    //    cameraPos.z += distance;

    //    int y = Camera.main.pixelHeight / 2;
    //    int x = Camera.main.pixelWidth / 2;


    //    transform.Translate((cameraPos + -transform.position) * 10 * Time.deltaTime);

    //    if (transform.localScale.x >= 0f && transform.localScale.y >= 0f && transform.localScale.z >= 0f)
    //    {
    //        transform.localScale += new Vector3(-0.2f, -0.2f, -0.2f) * Time.deltaTime;
    //    }

        float distCovered = (Time.time - startTime) * speed;
    float fracJourney = distCovered / distance;

    float x = Mathf.Lerp(startPos.x, target.x, fracJourney);
    float y = Mathf.Lerp(startPos.y, target.y, fracJourney);
    float z = Mathf.Lerp(startPos.z, target.z, fracJourney);

    transform.position = new Vector3(x + offset, y, z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        { 
            Debug.Log("Bah");

            Target target = other.GetComponent<Target>();

            if (target != null)
            {
                Debug.Log("Target isn't null");
                target.HelthDown();
            }

            GameObject e = Instantiate(hitting) as GameObject;
            e.transform.position = transform.position;

            Destroy(gameObject);
            Destroy(e, 0.25f);
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    // Debug.Log("Pizda: " + other.gameObject.tag);
    //    Debug.Log(other.gameObject);
    //    Debug.Log(other.gameObject.GetComponent<TargetF>());
    //    TargetF target = other.GetComponent<TargetF>();
    //    if (other.tag == "Target")
    //    {
    //        //other = target;

    //        if (target != null)
    //        {
    //            Debug.Log("Target isn't null");
    //            target.HelthDown();
    //        }
    //        Debug.Log("Target is null");

    //        GameObject e = Instantiate(hitting) as GameObject;
    //        e.transform.position = transform.position;

    //        // e.transform.localScale = transform.localScale;
    //        Destroy(gameObject);
    //        Destroy(e, 0.25f);
    //    }
    //}
}
