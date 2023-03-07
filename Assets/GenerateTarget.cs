using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject targetPref;
    
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

    void Start()
    {
        x = new Point(-8, 8);
        y = new Point(-4, 4);
        z = new Point(10, 15);
        GetTarget();
    }

    public void GetTarget()
    {
        target = Instantiate(targetPref, new Vector3(Random.Range(x.min, x.max),
                                                     Random.Range(y.min, y.max),
                                                     Random.Range(z.min, z.max)),
                                                     Quaternion.identity);
    }


    

    //void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Collision detected between " + gameObject.name + " and " + collision.gameObject.name);
    //}

    /*    private void Update()
        {
            target.transform.Translate(target.transform.position);
        }*/
}