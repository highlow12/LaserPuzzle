using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMirror : LaserObject
{
    void Start()
    {
        GameManager.Instance.addMirror();
    }

    public override void hitLaser(Vector3 dir)
    {
        base.hitLaser(dir);

        Vector3 mirrorLaserDirection = transform.right;
        shootLaser(transform.position, mirrorLaserDirection);
    }
}
