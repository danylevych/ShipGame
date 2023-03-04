using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField]
    private GameObject star;

    void Start()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        float distance = Camera.main.farClipPlane;
        cameraPos.z += distance / 1.3f;

        star.transform.position = cameraPos;

        // Quaternion starRotation = star.transform.rotation;
        star.transform.rotation = Quaternion.Euler(0f, -180f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
