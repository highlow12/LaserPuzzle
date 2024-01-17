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

          
    }

    public override void hitLaser(Vector3 dir)
    {
       /* if (/*dir - transform.forward == Vector3.zero *//* dir + transform.forward == Vector3.zero)
        {
            Debug.Log("receve");
            GameManager.Instance.laserReceve();

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
