using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserObject : GridObject
{
    RaycastHit hit;
    protected virtual void shootLaser(Vector3 origin, Vector3 dir)
    {
        
        Debug.DrawRay(origin + Vector3.up + Vector3.forward * 0.25f, dir * 9, Color.green, 10000);
        
        if (Physics.Raycast(origin + Vector3.up + Vector3.forward ,dir,out hit, 9))
        {
            
            //LaserManager.Instance.CallLaser(origin, hit.transform.position);

            LaserObject laser;
            if(hit.collider.TryGetComponent(out laser))
            {
                laser.hitLaser(transform.position);
            }
        }
        else
        {
            //LaserManager.Instance.CallLaser(origin, dir * 10);
        }

    }

    public virtual void hitLaser(Vector3 direction)
    {
        
    }
    private void Start()
    {
        //shootLaser(transform.position,transform.forward);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
