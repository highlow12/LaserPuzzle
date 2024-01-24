using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPortalOut : LaserObject
{
    public void ReceiveLaser(Vector3 dir)
    {
        // LaserPortalIn에서 전송된 레이저를 받아 처리
        shootLaser(transform.position, transform.forward);
    }

    public override void hitLaser(Vector3 dir)
    {
        // 이 포털에서 레이저를 발사
        //shootLaser(transform.position, dir);
    }
}
