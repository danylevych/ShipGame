using UnityEngine;

public class ConectGunsight : MonoBehaviour
{
    [SerializeField] private Transform shipPosition;
    [SerializeField] private GameObject dotGunsightPref;
    [SerializeField] private GameObject squreGunsightPref;

    private GameObject gunsight;

    private void Start()
    {
        gunsight = Instantiate((PlayerPrefs.GetInt("TypeGunsight", 1) == 0 ? dotGunsightPref : squreGunsightPref), shipPosition);
    }

    void Update()
    {
        gunsight.GetComponent<IGunsight>()?.SetPosition(shipPosition.transform.position);
    }
}
