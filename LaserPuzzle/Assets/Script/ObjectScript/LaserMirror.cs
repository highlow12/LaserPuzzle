using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMirror : LaserObject
{
    public override void hitLaser(Vector3 dir)
    {
        base.hitLaser(dir);

        float dotProduct = Vector3.Dot(transform.forward, dir);

        Vector3 mirrorLaserDirection;

        if (Mathf.Approximately(dotProduct, 0f))
        {
            mirrorLaserDirection = -transform.right;
        }
        else
        {
            mirrorLaserDirection = transform.right;
        }

        shootLaser(transform.position, mirrorLaserDirection);
    }
}