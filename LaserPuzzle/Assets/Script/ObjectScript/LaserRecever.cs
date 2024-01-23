using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRecever : LaserObject
{
    //public Material originalMat;
    //public Material changeMat;

    Material frontMat;
    protected override void Start()
    {
        
            //frontMat = transform.GetChild(1).GetComponent<MeshRenderer>().material;
        
        

        GameManager.Instance.addRecever();

        transform.Rotate(0, Random.Range(270, 450), 0);

          
    }

    public override void hitLaser(Vector3 dir)
    {
        Debug.Log("receve");
        GameManager.Instance.laserReceve();
        /* if (/*dir - transform.forward == Vector3.zero *//* dir + transform.forward == Vector3.zero)
         {


             transform.GetChild(1).GetComponent<MeshRenderer>().material = changeMat;
         }
         else
         {
             transform.GetChild(1).GetComponent<MeshRenderer>().material = originalMat;
         }*/
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
