using UnityEngine;

public class ConectGunsight : MonoBehaviour
{
    [SerializeField] private Transform shipPosition;
    [SerializeField] private GameObject gunsightPref;
    
    private GameObject gunsight;

    private void Start()
    {
        gunsight = Instantiate(gunsightPref, shipPosition);
    }

    void Update()
    {
        Dots dots = gunsight.GetComponent<Dots>();
        if (dots != null)
        {
            dots.SetPosForAllDots(gunsight.transform.position);
        }
    }
}
