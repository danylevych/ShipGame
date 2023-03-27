using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTarget : MonoBehaviour
{
    [SerializeField] private GameObject targetPref;

    public float timeGenerate;

    struct Point
    {
        public float min;
        public float max;

        public Point(float min = 0, float max = 0) 
        {
            this.max = max;
            this.min = min;
        }
    }

    private Point x;
    private Point y;
    private Point z;

    private GameObject target;
    private float timeDeath;
    private float timeOfLastTarget;

    private void Start()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        int partWidth = (int)(screenBounds.x / 2);
        int partHeight = (int)(screenBounds.y / 2);

        Vector3 centerWidth = new Vector3(partWidth, 0, 0);
        Vector3 centerHeight = new Vector3(0, partHeight, 0);

        Vector3 centerCamera = new Vector3(0, 0, Camera.main.farClipPlane * 3);

        int xMax = (int)Vector3.Lerp(centerWidth, centerCamera, 0.6f).x + 2;
        int yMax = (int)Vector3.Lerp(centerHeight, centerCamera, 0.6f).y * 2;


        timeDeath = 0f;

        x = new Point(-xMax, xMax);
        y = new Point(-yMax, yMax);
        z = new Point(60, 65);
        
        GetTarget();
    }

    private void Update()
    { 
        if (target == null)
        {
            if (Tools.Clock.CheckTime(ref timeDeath, timeGenerate))
            {
                GetTarget();

                ScoreManager.instance.AddScore();
                HPManager.instance.AddHP();
            }
        }

        if (Tools.Clock.CheckTime(ref timeOfLastTarget, 5f))
        {
            HPManager.instance.DelHP();
            timeOfLastTarget = 0f;
        }
    }

    public void GetTarget()
    {
        target = Instantiate(targetPref, new Vector3(Random.Range(x.min, x.max),
                                                     Random.Range(y.min, y.max),
                                                     Random.Range(z.min, z.max)),
                                                     Quaternion.identity);
    }
}
