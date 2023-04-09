using UnityEngine;


// +=========================================+
// |                                         |
// |  This script limiting the bullet count. |
// |                                         |
// +=========================================+

namespace Tools
{
    [System.Serializable]
    public class BulletLimit : MonoBehaviour
    {
        private static int maxCountVolley;
        public static int MaxBulletVolley {
            get
            {
                return maxCountVolley;
            }
        }

        private static int countBullet = 0;
        public static int CountBullet {
            get
            {
                return countBullet;
            }
        } 

        private static float timeOneReload;
        public static float TimeOneBullet {
            get 
            {
                return timeOneReload;
            }
        }


        private void Start()
        {
            // Check what type have a user ship.
            if(gameObject.tag == "StandartShip") 
            {
                maxCountVolley = UserShip.instance.VolleyCount;
                float timeAllReload = UserShip.instance.ReloadTime;
                timeOneReload = timeAllReload / maxCountVolley;
            }
        }

        public static bool IsReload()
        {
            if (countBullet == maxCountVolley)
            {
                return true;
            }

            return false;
        }

        public static void AddCountBullet()
        {
            countBullet++;
        }

        public static void ResetCount()
        {
            countBullet--;
        }
    }
}