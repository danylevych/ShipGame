using UnityEngine;


// +=========================================+
// |                                         |
// |  This script connects the gunsight for  |
// |                the ship.                |
// |                                         |
// +=========================================+

public class ConectGunsight : MonoBehaviour
{
    [SerializeField] private Transform shipPosition;
    [SerializeField] private GameObject dotGunsightPref;
    [SerializeField] private GameObject squreGunsightPref;

    private GameObject gunsight;

    private void Start()
    {
        gunsight = Instantiate((PlayerPrefs.GetInt("TypeGunsight", 0) == 0 ? dotGunsightPref : squreGunsightPref), shipPosition);
    }

    void Update()
    {
        gunsight.GetComponent<Gunsight>()?.SetPosition(shipPosition.transform.position);
    }
}
