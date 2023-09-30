using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var target = checkTargetPos();

        LaserManager.Instance.shootLaser(transform.position, target);
    }
    private void Update()
    {
        Debug.DrawRay(transform.position + Vector3.up, transform.forward * 10, Color.cyan);
    }
    RaycastHit hit;
    Vector3 checkTargetPos()
    {
        if (Physics.Raycast(transform.position + Vector3.up + transform.forward/2, transform.forward, out hit, 10))
        {
            Debug.Log(hit.collider.name);
            return hit.transform.position; ;
        }
        else
        {
            return(transform.forward * 10 );
        }
    }
    
}
