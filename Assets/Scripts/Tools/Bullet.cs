using UnityEngine;


// +=========================================+
// |                                         |
// |    This script describes the bullet.    |
// |                                         |
// +=========================================+

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 300f;
    [SerializeField] private GameObject hitting;

    private Vector3 startPos;
    private Vector3 target;

    private float offset;
    private float distance;
    private float startTime;
    private float sizeSphere;

    private void Start()
    {
        GameObject leftWing = GameObject.Find("Left");

        startTime = Time.time;
        target = new Vector3(0, 0, Camera.main.farClipPlane);
        startPos = transform.position;
        distance = Vector3.Distance(transform.position, target);

        sizeSphere = gameObject.GetComponent<SphereCollider>().radius;

        // Set the offset for the all bulet;
        if (Vector3.Distance(transform.position, leftWing.transform.position) <= 1)
        {
            offset = -0.46f;
        }
        else
        {
            offset = 0.46f;
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

        if (transform.localScale.x >= 0f && transform.localScale.y >= 0f && transform.localScale.z >= 0f)
        {
            transform.localScale += new Vector3(-0.15f, -0.15f, -0.15f) * Time.deltaTime;
            gameObject.GetComponent<SphereCollider>().radius = sizeSphere;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            Target target = other.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(10);
            }

            GameObject e = Instantiate(hitting) as GameObject;
            e.transform.position = transform.position;

            Destroy(gameObject);
            Destroy(e, 0.25f);
        }
    }
}
