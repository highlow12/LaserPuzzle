using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRecever : MonoBehaviour
{
    
    
    public Collider[] col;
    int a = 0;
    // Start is called before the first frame update
    void Update()
    {
        if (a == 0) { 
        col = Physics.OverlapSphere(transform.position, 1);
        foreach (var r in col)
        {
            if (r.CompareTag("Laser"))
            {
                Debug.Log("Clear");
                a++;
            }
        } }
    }
}
