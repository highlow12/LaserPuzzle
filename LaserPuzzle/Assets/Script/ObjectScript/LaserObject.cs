using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserObject : GridObject
{
    protected virtual void shootLaser(Vector3 origin, Vector3 target)
    {

    }

    public virtual void hitLaser(Vector3 direction)
    {

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
