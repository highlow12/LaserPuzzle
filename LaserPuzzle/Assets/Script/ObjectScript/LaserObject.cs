using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserObject : GridObject
{
    RaycastHit hit;
    public GameObject smoke;
    protected virtual void shootLaser(Vector3 origin, Vector3 dir)
    {
        if (GameManager.Instance.Remainchance == 0)
        {
            smoke.SetActive(true);
        }
        else
        {
            Debug.DrawRay(origin + Vector3.up /*+ dir.normalized * 0.25f*/, dir * 9, Color.green, 10000);

            if (Physics.Raycast(origin + Vector3.up /*+ dir.normalized * 0.25f*/, dir, out hit, 9.75f))
            {

                LaserManager.Instance.shootLaser(origin, hit);
                //Debug.Log(hit.transform.position);
                /*if (hit.collider.TryGetComponent(out LaserObject laser))
                {
                    laser.hitLaser(dir);
                }*/
            }
            else
            {
                LaserManager.Instance.shootLaser(origin, transform.position + dir * 9);
            }
        }

    }

    public virtual void hitLaser(Vector3 dir)
    {
        
    }
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
