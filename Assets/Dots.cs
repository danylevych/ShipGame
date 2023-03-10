using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dots : MonoBehaviour
{
    [SerializeField]
    private GameObject dotPref;
    [SerializeField]
    private Vector3 positionFirst;
    
    private GameObject[] dots;
    public int offsetPos = 3;
    public int countOfDots = 13;


    private void Start()
    {
        dots = new GameObject[countOfDots];
        dots[0] = Instantiate(dotPref, positionFirst, Quaternion.identity);

        for (int i = 1; i < countOfDots; i++)
        {
            Vector3 parentPos = dots[i - 1].transform.position;
            parentPos.z += offsetPos;
            dots[i] = Instantiate(dots[i - 1], parentPos, Quaternion.identity);
        }
    }


    public void SetPosForAllDots(Vector3 newPos)
    {
        Vector3 cameraPos = Camera.main.transform.position;
        float distance = Camera.main.farClipPlane;
        cameraPos.z += distance;

        newPos.z = positionFirst.z;

        for(int i = 0; i < countOfDots; i++, newPos.z += offsetPos)
        {
            var transform = Vector3.Lerp(newPos, cameraPos, 0.05f * (i + 1));

            transform.z = dots[i].transform.position.z;

            dots[i].transform.position = transform;

        }
    }
}