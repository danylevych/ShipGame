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

        public static bool IsMustReloading()
        {
            /*
                The countBullet in the start of game equales 0, that is mean the volley
                is full. But the maxCountVolley - some non zero value, consequently we
                must use the below code or do samething like that countBullet = 0.
            */
            if (countBullet + maxCountVolley == maxCountVolley)
            {
                return false;
            }

            return true;
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