using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRecever : LaserObject
{
    //public Material originalMat;
    //public Material changeMat;
    GameObject effect = null;
    
    protected override void Start()
    {
        GameManager.Instance.addRecever();

        transform.Rotate(0, Random.Range(0, 360), 0);

        GameManager.Instance.StageReset += _Reset;
    }

    public override void hitLaser(Vector3 dir)
    {
        Debug.Log("receve");
        GameManager.Instance.laserReceve();

        effect = EffectManager.Instance.GetExpolsion(transform.position);
        AudioManager.Instance.PlaySFX(AudioManager.Sfx.explosion);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    void _Reset()
    {
        Destroy(effect);
        effect = null;

        gameObject.SetActive(true);
    }
}
