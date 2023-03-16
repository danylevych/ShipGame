using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoit;
    [SerializeField]
    private GameObject bullet;

    public float speed = 10;
    private bool isPressSpace;
    private float timeOfEachBullet;


    private void Start()
    {
        isPressSpace = false;
        timeOfEachBullet = 0f;
    }

    void Update()
    {
        ChackInput();

        timeOfEachBullet += Time.deltaTime;

        if (isPressSpace && timeOfEachBullet >= 0.17f)
        {
            Shoot();
            timeOfEachBullet = 0f;
        }
    }

    private void ChackInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPressSpace = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isPressSpace = false;
        }
    }

    void Shoot()
    {
        if (bullet != null)
        {
            GameObject newBullet = Instantiate(bullet, firePoit.position, Quaternion.identity);
            Destroy(newBullet, 2);
        }
    }
}
