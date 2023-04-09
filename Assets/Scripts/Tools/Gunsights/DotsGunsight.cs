using UnityEngine;


// +=========================================+
// |                                         |
// | This script describes the dot gunsight. |
// |                                         |
// +=========================================+

public class DotsGunsight : Gunsight
{
    [SerializeField] private GameObject dotPref;
    [SerializeField] private Vector3 positionFirst;
    
    private GameObject[] dots;  // The array of the dots.
    public int offsetPos;       // The offset between two dots.
    public int countOfDots;     // The count of the dots in an array.


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

    public override void SetPosition(Vector3 newPos)
    {
        Vector3 cameraPos = Camera.main.transform.position;
        cameraPos.z += Camera.main.farClipPlane;

        dots[0].transform.position = Vector3.Lerp(newPos, cameraPos, positionFirst.z / 100f);

        for (int i = 1; i < countOfDots; i++)
        {
            dots[i].transform.position = Vector3.Lerp(dots[i - 1].transform.position, cameraPos, (offsetPos / 100.0f));
        }
    }
}
