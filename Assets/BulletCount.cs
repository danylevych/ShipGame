using UnityEngine;
using UnityEngine.UI;

public class BulletCount: MonoBehaviour
{
    [SerializeField] private Text countText;

    private void Start()
    {
        countText.text = Tools.BulletLimit.MaxBulletVolley.ToString("0");
    }

    private void Update()
    {
        countText.text = (Tools.BulletLimit.MaxBulletVolley - Tools.BulletLimit.CountBullet).ToString("0");
    }
}
