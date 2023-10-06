using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public int max_out_laser = 1;
    RaycastHit hit;
    public Collider[] col;
    // Start is called before the first frame update
    void Start()
    {
        col = Physics.OverlapSphere(transform.position, 1);
        foreach (var r in col)
        {
            if (r.CompareTag("Laser"))
            {
                var target = checkTargetPos();

                LaserManager.Instance.shootLaser(transform.position, target);
            }
        }
    }
    Vector3 checkTargetPos()
    {
        if (Physics.Raycast(transform.position + Vector3.up + transform.right / 2, transform.right, out hit, 10))
        {
            Debug.Log("hit" + hit.collider.name);
            return hit.transform.position;
        }
        else
        {
            Debug.Log("nohit_mirror");
            return (transform.position + transform.right * 10);
        }
    }
    int a = 0;
    private void Update()
    {
        Debug.DrawRay(transform.position + Vector3.up + transform.right / 2, transform.right * 10, Color.cyan);
        Debug.DrawRay(transform.position + transform.up * -2, transform.up* 10, Color.red);

        if (a < max_out_laser)
        {
            a++;
            col = Physics.OverlapSphere(transform.position, 1);
            foreach (var r in col)
            {
                if (r.CompareTag("Laser"))
                {
                    var target = checkTargetPos();

                    LaserManager.Instance.shootLaser(transform.position, target);
                }
            }
        }
           
        
    }

}
