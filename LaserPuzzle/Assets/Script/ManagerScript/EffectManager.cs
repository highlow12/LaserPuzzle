using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public GameObject particleSystems;
    public GameObject smokeEffect;
    public float time = 1;

    static public EffectManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static EffectManager Instance
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

    public void GetExpolsion(Vector3 pos)
    {
        var effect = Instantiate(particleSystems);
        effect.transform.position = pos;
        //var effect2 = Instantiate(smokeEffect);
        //Destroy(effect, time);
        //Destroy(effect2, time);
    }

    
}
