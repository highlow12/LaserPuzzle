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
            // 레이저가 이 포털에 충돌하면 연결된 포털로 레이저를 전송
            connectedPortal.ReceiveLaser(dir);
        }
    }
}

