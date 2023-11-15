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
            // �������� �� ���п� �浹�ϸ� ����� ���з� �������� ����
            connectedPortal.ReceiveLaser(dir);
        }
    }
}

