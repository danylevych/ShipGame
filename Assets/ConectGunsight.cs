using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConectGunsight : MonoBehaviour
{
    [SerializeField]
    private GameObject gunsightPref;
    
    [SerializeField]
    private Transform shipPosition;

    [SerializeField]
    private float speed = 80;

    private GameObject gunsight;

    private void Start()
    {
        gunsight = Instantiate(gunsightPref, shipPosition);
    }

    void Update()
    {
        Vector3 direction = GetDistance() * speed * Time.deltaTime;
        gunsight.transform.rotation = Quaternion.Inverse(new Quaternion(direction.x,
                                                                        direction.y,
                                                                        direction.z,
                                                                        gunsight.transform.rotation.w));
        var dots = gunsight.GetComponent<Dots>();
        if (dots != null)
        {
            Vector3 cameraCord2 = Camera.main.transform.position;
            cameraCord2.z += Camera.main.farClipPlane;
            dots.SetPosForAllDots(shipPosition.position);
        }
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
