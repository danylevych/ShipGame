using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationGunsight : MonoBehaviour
{
    [SerializeField]
    private Transform shipPosition;

    [SerializeField]
    private float speed = 80;


    void Update()
    {
        Vector3 direction = GetDistance() * speed * Time.deltaTime;

        gameObject.transform.rotation = Quaternion.Inverse(new Quaternion(direction.x, direction.y, direction.z, gameObject.transform.rotation.w));
    }


    Vector3 GetDistance()
    {
        Vector3 shipCord = shipPosition.transform.position;
        Vector3 cameraCord1 = Camera.main.transform.position;
        Vector3 cameraCord2 = Camera.main.transform.position;
        cameraCord2.z += Camera.main.farClipPlane;


        Vector3 distShipCam = shipCord + cameraCord1;
        Vector3 distCam = cameraCord1 + cameraCord2;

        return distCam - distShipCam;
    }
}
