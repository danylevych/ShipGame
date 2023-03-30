using UnityEngine;

public class SqureGunsight : IGunsight
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

        gameObject.transform.position = Vector3.LerpUnclamped(newPos, cameraPos, distShipToGunsight / 100f);
    }
}
