using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPortalIn : LaserObject
{
    public LaserPortalOut connectedPortal;

    public override void hitLaser(Vector3 dir)
    {
        if (connectedPortal != null)
        {
            //Debug.Log((dir.normalized - transform.forward).normalized);
            if (transform.forward == dir.normalized || transform.forward == dir.normalized * -1)
            {
                connectedPortal.ReceiveLaser(dir);
            }
            // �������� �� ���п� �浹�ϸ� ����� ���з� �������� ����
                connectedPortal.ReceiveLaser(dir);
        }
    }
}

