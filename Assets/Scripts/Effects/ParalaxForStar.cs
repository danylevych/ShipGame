using UnityEngine;


public class ParalaxForStar : MonoBehaviour
{
    private Vector3 starRotation;
    private float speed = 10;

    private void Start()
    {
        starRotation.x += Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        starRotation.y += Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
        starRotation.z = 0;

        transform.rotation = Quaternion.Euler(-starRotation.x, starRotation.y, starRotation.z);
    }

    private void Update()
    {
        starRotation.x += Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        starRotation.y += Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

        if (System.Math.Abs(transform.rotation.x) <= 25 && System.Math.Abs(transform.rotation.y) <= 25)
        {
            transform.rotation = Quaternion.Euler(-starRotation.x, starRotation.y, starRotation.z);
        }
    }
}
