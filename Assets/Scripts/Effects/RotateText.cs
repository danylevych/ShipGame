using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateText : MonoBehaviour
{
    private void Start()
    {
        transform.rotation = Camera.main.transform.rotation;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Inverse(Camera.main.transform.rotation);
    }
}
