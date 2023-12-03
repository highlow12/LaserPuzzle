using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : LaserObject
{

    protected override void shootLaser(Vector3 origin, Vector3 dir)
    {
        origin = transform.position;
        dir = transform.forward;
        base.shootLaser(origin, dir);
        //Debug.Log("origin: " + origin + " dir: " + dir);
    }

    protected override void Start()
    {
        base.Start();

       GameManager.Instance.LaserStartShoot += shootLaser;
    }

    


}
