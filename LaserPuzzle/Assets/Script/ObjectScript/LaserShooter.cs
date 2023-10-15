using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : LaserObject
{
    protected override void Start()
    {
        base.Start();

        shootLaser(transform.position, transform.forward);
    }


}
