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


    // Update is called once per frame
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
       
        // bullet = gameObject.GetComponent<Bullet>(); 

        if (bullet != null)
        {
            Debug.Log("Bah");
            GameObject newBullet = Instantiate(bullet, firePoit.position, Quaternion.identity);
            // newBullet.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1 * speed * Time.deltaTime));
            Destroy(newBullet, 3);
        }
        // bullet = gameObject.AddComponent<Bullet>();
    }
}
