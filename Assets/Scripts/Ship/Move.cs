using UnityEngine;


// +=========================================+
// |                                         |
// | This script moves and rotates the ship. |
// |                                         |
// +=========================================+

public class Move : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject obj;
    [SerializeField] private float maxMinRotationAngle;

    struct IsPressed
    {
        public bool W;
        public bool S;
        public bool A;
        public bool D;

        public IsPressed(bool value = false)
        {
            W = S = A = D = value;
        }
    }

    private IsPressed isPressed;


    private void Start()
    {
        isPressed = new IsPressed();
    }

    private void Update()
    {

        KeyInput();

        MoveShip();
    }

    private void LateUpdate()
    {
        // Rotating the camera in the opposite side that ship rotate.
        float planeAngle = LimitAngle(obj.transform.eulerAngles.z);
        float planeNewAngle = Mathf.Clamp(Mathf.LerpAngle(Camera.main.transform.rotation.z, planeAngle, 0.25f), -10, 10);

        Camera.main.transform.rotation = Quaternion.Inverse(Quaternion.Euler(obj.transform.rotation.eulerAngles.x,
                                                                             obj.transform.rotation.eulerAngles.y,
                                                                             planeNewAngle));
    }


    private void KeyInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            isPressed.W = true;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            isPressed.W = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            isPressed.S = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            isPressed.S = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            isPressed.A = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            isPressed.A = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            isPressed.D = true;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            isPressed.D = false;
        }
    }

    private void MoveShip()
    {
        Vector3 moveTo = new(0, 0, 0);

        if (isPressed.W)
        {
            moveTo.y = 1;
        }
        else if (isPressed.S)
        {
            moveTo.y = -1;
        }

        if (isPressed.A && !isPressed.D)
        {
            moveTo.x = -1;
            RotateShip(maxMinRotationAngle, Time.deltaTime * 2);
        }
        else if (isPressed.D && !isPressed.A)
        {
            moveTo.x = 1;
            RotateShip(-maxMinRotationAngle, Time.deltaTime * 2);
        }
        else
        {
            RotateShip(0, Time.deltaTime * 4);
        }

        ShipMoving(moveTo);
    }

    private float LimitAngle(float angle)
    {
        return (angle > 180) ? angle - 360 : angle;
    }

    private void ShipMoving(Vector3 moveTo)
    {
        obj.transform.position += moveTo * speed * Time.deltaTime;
    }

    private void RotateShip(float angle, float speed)
    {
        // Rotating the ship in the left or right side.
        float currentAngle = LimitAngle(obj.transform.rotation.eulerAngles.z);
 
        transform.rotation = Quaternion.Euler(obj.transform.rotation.eulerAngles.x,
                                              obj.transform.rotation.eulerAngles.y,
                                              Mathf.Clamp(Mathf.LerpAngle(currentAngle, angle, speed),
                                              -maxMinRotationAngle,
                                              maxMinRotationAngle));
    }
}
