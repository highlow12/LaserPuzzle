using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHalfMirror : LaserObject
{
    void Start()
    {
        GameManager.Instance.addHalfMirror();
    }

    public override void hitLaser(Vector3 dir)
    {
        base.hitLaser(dir);

        Vector3 mirrorLaserDirectionRight = transform.right;
        Vector3 mirrorLaserDirectionForward = transform.forward;

        shootLaser(transform.position, mirrorLaserDirectionRight);
        shootLaser(transform.position, mirrorLaserDirectionForward);
    }
}
