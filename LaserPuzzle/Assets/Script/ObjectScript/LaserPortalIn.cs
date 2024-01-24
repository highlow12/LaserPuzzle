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
            if(
                (dir.normalized - transform.forward).normalized == Vector3.zero 
                || (dir.normalized - transform.forward).normalized== Vector3.right
                || (dir.normalized - transform.forward).normalized == Vector3.right*-1)
            // �������� �� ���п� �浹�ϸ� ����� ���з� �������� ����
                connectedPortal.ReceiveLaser(dir);
        }
    }
}

