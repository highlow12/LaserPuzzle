using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPortalOut : LaserObject
{
    public void ReceiveLaser(Vector3 dir)
    {
        // LaserPortalIn���� ���۵� �������� �޾� ó��
        shootLaser(transform.position, transform.forward);
    }

    public override void hitLaser(Vector3 dir)
    {
        // �� ���п��� �������� �߻�
        //shootLaser(transform.position, dir);
    }
}
