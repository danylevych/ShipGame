using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 12;
    public GameObject obj;


    private float maxMinRotationAngle;

    private bool isRotation; 
    private Vector3 rememberRotLeft;
    private Vector3 rememberRotRight;
    // private Vector3 rememberRotRight;

    struct IsPressed
    {
        public bool W;
        public bool S;
        public bool A;
        public bool D;
        public bool Space;
    }

    IsPressed isPressed;

    void Start()
    {
        rememberRotLeft = new Vector3(0f, 0f, 1);
        rememberRotRight = new Vector3(0f, 0f, -1);

        maxMinRotationAngle = 20;

        isRotation = false;

        isPressed.A = false;
        isPressed.W = false;
        isPressed.D = false;
        isPressed.S = false;
        isPressed.Space = false;
    }

    void Update()
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPressed.Space = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isPressed.Space = false;
        }


        KeyInput();
    }

    void KeyInput()
    {
        isRotation = false;

        Vector3 moveTo = new(0, 0, 0);
        Vector3 rotation = new(0, 0, 0);

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
            rotation.z = rememberRotLeft.z;
            isRotation = true;
        }
        else if (isPressed.D && !isPressed.A)
        {
            moveTo.x = 1;
            rotation.z = rememberRotRight.z;
            isRotation = true;
        }


        obj.transform.position += moveTo * speed * Time.deltaTime;

        float currentAngle = LimitAngle(obj.transform.eulerAngles.z);

        float clampedAngle = Mathf.Clamp(currentAngle, -maxMinRotationAngle, maxMinRotationAngle);
        var temp = Quaternion.Euler(0, 0, clampedAngle).eulerAngles;

        transform.eulerAngles = temp += speed * Time.deltaTime * rotation;


        if (!isRotation)
        {
            if ((int)LimitAngle(obj.transform.eulerAngles.z) != 0)
            {
                if (LimitAngle(obj.transform.eulerAngles.z) < 0)
                {
                    obj.transform.eulerAngles += 2 * speed * Time.deltaTime * (rememberRotLeft);
                }
                else if(LimitAngle(obj.transform.eulerAngles.z) > 0)
                {
                    obj.transform.eulerAngles += 2 * speed * Time.deltaTime * (rememberRotRight);
                }                   
            }
            else if (System.Math.Abs((int)LimitAngle(obj.transform.eulerAngles.z)) - 0 < 0.1)
            {
                obj.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        }
    }


    void LateUpdate()
    {
        float planeAngle = LimitAngle(obj.transform.eulerAngles.z);
        float planeNewAngle = Mathf.Clamp(planeAngle, -7, 7);

        Camera.main.transform.rotation = Quaternion.Inverse(Quaternion.Euler(obj.transform.rotation.eulerAngles.x,
                                                                             obj.transform.rotation.eulerAngles.y,
                                                                             planeNewAngle / 1.72f));
    }

    private float LimitAngle(float angle)
    {
        return (angle > 180) ? angle - 360 : angle;
    }
}
