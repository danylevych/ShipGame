using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject targetPref;

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

    private float timeOfLastTarget;

    private void Start()
    {
        x = new Point(-8, 8);
        y = new Point(-6, 6);
        z = new Point(40, 45);
        timeOfLastTarget = 0f;
        GetTarget();
    }

    private void Update()
    { 
        timeOfLastTarget += Time.deltaTime;

        if (timeOfLastTarget >= 5f)
        {
            HPManager.instance.DelHP();
            timeOfLastTarget = 0f;
        }

        if (target == null)
        {
            new WaitForSeconds(timeGenerate);

            GetTarget();

            ScoreManager.instance.AddScore();
            HPManager.instance.AddHP();
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
