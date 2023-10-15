using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRecever : LaserObject
{
    protected override void Start()
    {

        GameManager.Instance.addRecever();
    }

    public override void hitLaser(Vector3 dir)
    {
        if (/*dir - transform.forward == Vector3.zero */ dir + transform.forward == Vector3.zero)
        {
            Debug.Log("receve");
            GameManager.Instance.laserReceve();
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
