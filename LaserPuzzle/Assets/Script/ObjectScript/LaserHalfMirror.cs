using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHalfMirror : LaserObject
{
    public override void hitLaser(Vector3 dir)
    {
        base.hitLaser(dir);

        Debug.Log("hitLaserHalfMirror");

        Vector3 mirrorLaserDirectionRight = Quaternion.Euler(0, 90, 0) * dir;
        Vector3 mirrorLaserDirectionForward = dir;

        shootLaser(transform.position, mirrorLaserDirectionRight);
        shootLaser(transform.position, mirrorLaserDirectionForward);
    }
}