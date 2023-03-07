using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBulletAndTarget : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Target(Clone)")
        {
            Destroy(gameObject);
            return;
        }
        else if (collision.gameObject.name == "Bullet(Clone)")
        {
            // Об'єкт 1 та об'єкт 2 не зможуть стикатися між собою
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}
