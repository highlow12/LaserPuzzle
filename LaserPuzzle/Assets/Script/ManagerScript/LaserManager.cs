using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaserManager : MonoBehaviour
{
    static LaserManager instance = null;

    public GameObject Laser;

    List<Transform> lasers = new List<Transform>();

    public static LaserManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            else
            {
                return instance;
            }
        }
    }

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

    public void shootLaser(Vector3 origin, Vector3 target)
    {
        var laser = Instantiate(Laser).transform;
        laser.SetParent(transform);

        var dir = target - origin;


        laser.position = origin + dir * 0.5f + Vector3.up*0.5f;
        var i = dir.x+dir.z;
        laser.localScale = new Vector3(laser.localScale.x, laser.localScale.y, i);
        
        dir = dir.normalized;

        laser.rotation = Quaternion.Euler(dir);

        //laser.gameObject.SetActive(false);

        lasers.Add(laser);

    }

    private void showLasers()
    {
        foreach (Transform t in lasers) 
        {
            t.gameObject.SetActive(true);
        }
    }
    private void Start()
    {
        lasers.Clear();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {

        }
    }

}


