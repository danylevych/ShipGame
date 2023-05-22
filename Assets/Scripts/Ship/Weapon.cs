using UnityEngine;


// +=========================================+
// |                                         |
// |   This script describes the weapon of   |
// |                a ship.                  |
// |                                         |
// +=========================================+

public class Weapon : MonoBehaviour
{
    [SerializeField] public GameObject bulletPref;
    [SerializeField] public Transform leftFirePoit;
    [SerializeField] public Transform rightFirePoit;
    [SerializeField] public AudioSource shootingAudio;

    public float speed = 10;
    private bool isReload;
    private bool isShooting;
    private float timeOfEachBullet;

    private void Start()
    {
        isShooting = false;
        isReload = false;
        timeOfEachBullet = 0f;
    }

    private void Update()
    {
        CheckInput();

        if (!isReload)
        {
            BulletUI.instance.Normal();  // Setting the normal animation for UI.
        }
        
        // If the weapon doesn't reload, the time between two bullet is normal and the shoot key was pressed.
        if (!isReload && Tools.Clock.CheckTime(ref timeOfEachBullet, 0.17f) && isShooting)
        {
            Shoot();
            Tools.BulletLimit.AddCountBullet();
        }
        else if (isReload)
        {
            Reload();
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isShooting = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isShooting = false;
        }
        
        /*
            The isReload variable will get the value true when the key R will press,
            and the guns will must reload, or count using bullets will be equal the 
            maximum count in one volley, what wiil be mean - user used all bullets.
        */
        if ((Input.GetKeyDown(KeyCode.R) && Tools.BulletLimit.IsMustReloading()) ||
            (Tools.BulletLimit.CountBullet == Tools.BulletLimit.MaxBulletVolley))
        {
            isReload = true;
        }
    }

    private void Shoot()
    {
        if (bulletPref != null)
        {
            shootingAudio.Play();

            GameObject leftBullet = Instantiate(bulletPref, leftFirePoit.position, Quaternion.identity);
            GameObject rightBullet = Instantiate(bulletPref, rightFirePoit.position, Quaternion.identity);

            Destroy(leftBullet, 2f);
            Destroy(rightBullet, 2f);
        }
    }

    private void Reload()
    {
        BulletUI.instance.Reload();  // Set the reloading animation.

        if (Tools.Clock.CheckTime(Tools.BulletLimit.TimeOneBullet))  // Checking if a pair of bullet was insert in volley.
        {
            Tools.BulletLimit.ResetCount();
        }

        if (Tools.BulletLimit.CountBullet == 0)
        {
            isReload = false;
        }
    }
}
