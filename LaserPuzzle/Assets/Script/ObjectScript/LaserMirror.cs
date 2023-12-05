using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMirror : LaserObject
{
    public override void hitLaser(Vector3 dir)
    {
        base.hitLaser(dir);

        Vector3 mirrorLaserDirection = Quaternion.Euler(0, 90, 0) * dir;
        shootLaser(transform.position, mirrorLaserDirection);
    }
}