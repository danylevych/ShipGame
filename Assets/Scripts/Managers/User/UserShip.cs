using UnityEngine;

public class UserShip : MonoBehaviour
{
    public static UserShip instance;

    [SerializeField] private ShipManager manager;
    [SerializeField] private Transform leftWeapon;
    [SerializeField] private Transform rightWeapon;

    private int voley;
    public int VoleyCount {
        get
        {
            return voley;
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

        voley = manager.GetShip(userChoese).voley;
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
