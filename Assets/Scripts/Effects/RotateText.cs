using UnityEngine;


// +=========================================+
// |                                         |
// | This script rotate the text according   |
// |      to the user's ship rotation.       |
// |                                         |
// +=========================================+

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
