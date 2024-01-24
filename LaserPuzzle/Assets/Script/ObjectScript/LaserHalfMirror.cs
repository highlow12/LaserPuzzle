using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHalfMirror : LaserObject
{
    public override void hitLaser(Vector3 dir)
    {
        base.hitLaser(dir);

        if (dir.normalized == transform.forward * -1)
        {
            shootLaser(transform.position, transform.right * -1);
            shootLaser(transform.position, dir);
        }
        else if (dir.normalized == transform.right)
        {
            shootLaser(transform.position, transform.forward);
            shootLaser(transform.position, dir);
        }
    }
}