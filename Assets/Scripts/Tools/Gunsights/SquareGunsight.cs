using UnityEngine;


// +=========================================+
// |                                         |
// |    This script describes the square     |
// |                gunsight.                |
// |                                         |
// +=========================================+

public class SquareGunsight : Gunsight
{
    [SerializeField] private int distShipToGunsight;

    private void Start()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                    gameObject.transform.position.y,
                                                    distShipToGunsight);
    }

    public override void SetPosition(Vector3 newPos)  
    {
        Vector3 cameraPos = Camera.main.transform.position;
        cameraPos.z += Camera.main.farClipPlane;

        Vector3 pos = Vector3.LerpUnclamped(newPos, cameraPos, distShipToGunsight / 100f);
        gameObject.transform.position = pos;

        gameObject.transform.rotation = Quaternion.Euler(new Vector3(pos.x, pos.y, 0));
    }
}
