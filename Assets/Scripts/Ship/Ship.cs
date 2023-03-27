using UnityEngine;

[System.Serializable]
public class Ship
{
    public string name;
    public Sprite shipSprite;

    public AudioClip shootingAudio;
    public GameObject bulletPref;

    public Vector3 leftWeapon;
    public Vector3 rightWeapon;

    public int voley;
    public float reloadingTime;
}
