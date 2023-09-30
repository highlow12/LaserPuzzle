using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    public static LaserManager instance = null;
    public GameObject laser;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static LaserManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void shootLaser(Vector3 shooterPos, Vector3 targetPos)
    {
        var vec = targetPos - shooterPos;

        var scale = vec.x + vec.y + vec.z;

        var deg = Vector3.SignedAngle(Vector3.forward, vec, Vector3.up);
        Debug.Log(deg);

        var LaserNew = Instantiate(laser, transform).transform;
    
        LaserNew.localPosition= shooterPos + vec / 2;
        LaserNew.localScale = new Vector3(LaserNew.localScale.x, LaserNew.localScale.y, scale);
        LaserNew.rotation = Quaternion.Euler(0, deg, 0);
        
    }   

    public void Start()
    {
        //shootLaser(new(0,1,0), new(0,1,5));
    }
}
