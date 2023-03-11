using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConectGunsight : MonoBehaviour
{
    [SerializeField]
    private GameObject gunsightPref;
    
    [SerializeField]
    private Transform shipPosition;

    private GameObject gunsight;

    private void Start()
    {
        gunsight = Instantiate(gunsightPref, shipPosition);
    }

    void Update()
    {
        var dots = gunsight.GetComponent<Dots>();
        if (dots != null)
        {
            dots.SetPosForAllDots(gunsight.transform.position);
        }
    }
}
