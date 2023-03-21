using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform leftFirePoit;
    [SerializeField] private Transform rightFirePoit;
    [SerializeField] private GameObject bulletPref;

    public float speed = 10;
    private bool isPressSpace;
    private bool isPressReload;
    private float timeOfEachBullet;

    private void Start()
    {
        isPressSpace = false;
        isPressReload = false;
        timeOfEachBullet = 0f;
    }

    private void Update()
    {
        ChackInput();

        if (!isPressReload && Tools.Clock.CheckTime(ref timeOfEachBullet, 0.17f) && isPressSpace)
        {
            Shoot();
            Tools.BulletLimit.AddCountBullet();
        }
        else if (isPressReload)
        {
            Reload();
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

        if (Input.GetKeyDown(KeyCode.R) || Tools.BulletLimit.IsReload())
        {
            isPressReload = true;
        }
    }

    private void Shoot()
    {
        if (bulletPref != null)
        {
            GameObject leftBullet = Instantiate(bulletPref, leftFirePoit.position, Quaternion.identity);
            GameObject rightBullet = Instantiate(bulletPref, rightFirePoit.position, Quaternion.identity);

            Destroy(leftBullet, 1f);
            Destroy(rightBullet, 1f);
        }
    }

    private void Reload()
    {
        if (Tools.Clock.CheckTime(Tools.BulletLimit.TimeOneBullet))
        {
            Tools.BulletLimit.ResetCount();
        }

        if (Tools.BulletLimit.CountBullet == 0)
        {
            isPressReload = false;
        }
    }
}
