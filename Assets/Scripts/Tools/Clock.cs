using UnityEngine;

namespace Tools
{
    public static class Clock 
    {
        public static bool CheckTime(ref float nowTime, float whatTime)
        {
            nowTime += Time.deltaTime;

            if (nowTime >= whatTime)
            {
                nowTime = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        private static float nowTime;
        public static bool CheckTime(float whatTime)
        {
            nowTime += Time.deltaTime;

            if (nowTime >= whatTime)
            {
                nowTime = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}