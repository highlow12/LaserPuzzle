using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaserManager : MonoBehaviour
{
    static LaserManager instance = null;

    public GameObject Laser;
    public static LaserManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            else
            {
                return instance;
            }
        }
    }
    struct Vector3s
    {
        public Vector3 origin;
        public Vector3 target;
    }

    Queue<Vector3s> queue;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }



    public void CallLaser(Vector3 origin, Vector3 target)
    {
        Vector3s V;
        V.origin = origin;
        V.target = target;

        queue.Enqueue(V);

    }

    public void MakeLaser()
    {
        foreach (var item in queue)
        {
            var laser = Instantiate(Laser);

            laser.transform.position = (item.target - item.origin) / 2;

            //스케일조정
        }
    }

}


