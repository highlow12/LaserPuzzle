using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHalfMirror : LaserObject
{
    public override void hitLaser(Vector3 dir)
    {
        base.hitLaser(dir);

        float dotProduct = Vector3.Dot(transform.forward, dir);

        Vector3 mirrorLaserDirection;
        Vector3 mirrorLaserDirectionForward = dir;

        if (Mathf.Approximately(dotProduct, 0f))
        {
            mirrorLaserDirection = -transform.right;

        }
        else
        {
            mirrorLaserDirection = transform.right;
        }

        shootLaser(transform.position, mirrorLaserDirection);
        shootLaser(transform.position, mirrorLaserDirectionForward);
    }
}