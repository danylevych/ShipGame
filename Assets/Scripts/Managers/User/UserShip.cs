using UnityEngine;


// +=========================================+
// |                                         |
// |  This script consist of the information |
// |      about the current user ship.       |
// |                                         |
// +=========================================+

public class UserShip : MonoBehaviour
{
    public static UserShip instance;

    [SerializeField] private ShipManager manager;    // Consist of all info about all ships.
    [SerializeField] private Transform leftWeapon;
    [SerializeField] private Transform rightWeapon;

    private int volley;
    public int VolleyCount {
        get
        {
            return volley;
        }
    }

    private float reloadTime;
    public float ReloadTime {
        get
        {
            return reloadTime;
        }
    }


    private void Awake()
    {
        int userChoese = PlayerPrefs.GetInt("userShip", 0);

        volley = manager.GetShip(userChoese).volley;
        reloadTime = manager.GetShip(userChoese).reloadingTime;

        gameObject.tag = manager.GetShip(userChoese).name;

        gameObject.GetComponent<SpriteRenderer>().sprite = manager.GetShip(userChoese).shipSprite;

        gameObject.GetComponentInChildren<Weapon>().bulletPref = manager.GetShip(userChoese).bulletPref;
        gameObject.GetComponentInChildren<Weapon>().shootingAudio.clip = manager.GetShip(userChoese).shootingAudio;

        leftWeapon.localPosition = manager.GetShip(userChoese).leftWeapon;
        rightWeapon.localPosition = manager.GetShip(userChoese).rightWeapon;

        if(instance == null)
        {
            instance = this;
        }
    }
}
