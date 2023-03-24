using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private GameObject star;

    void Start()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        float distance = Camera.main.farClipPlane;
        cameraPos.z += distance / 1.3f;

        star.transform.position = cameraPos;

        star.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
    }
}
