using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;


public class LaserManager : MonoBehaviour
{
    static LaserManager instance = null;

    public GameObject Laser;

    List<Transform> lasers = new();

    public float laserOffset = 0.5f;

    public float laserDuration = .5f;
    public float LaserClearDelay = 3;

    public Ease ease = Ease.Linear;

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
    private void Start()
    {
        lasers.Clear();
        GameManager.Instance.StageReset += stageReset;

    }
    public void shootLaser(Vector3 origin, RaycastHit hit)
    {
        //Debug.Log(target);
        Vector3 target = hit.transform.position;

        var laser = Instantiate(Laser).transform;
        laser.SetParent(transform);

        var dir = target - origin;

        //laser.position = origin + dir * 0.5f + Vector3.up* laserOffset;
        //Debug.Log(laser.position);
        var i = dir.x + dir.z;
        //laser.localScale = new Vector3(laser.localScale.x, laser.localScale.y, Mathf.Abs(i));

        

        Vector3 angle = new(0, Vector3.SignedAngle(Vector3.forward, dir.normalized, Vector3.up), 0);
        //Debug.Log(angle);

        laser.localRotation = Quaternion.Euler(angle);
        //laser.gameObject.SetActive(false);

        laser.position = origin + Vector3.up * laserOffset;
        //laser.DOMove(origin + dir * 0.5f + Vector3.up * laserOffset, laserDuration).SetSpeedBased();

        laser.localScale = Vector3.one*0.1f;
        laser.DOScale(new Vector3(laser.localScale.x, laser.localScale.y, Mathf.Abs(i)), laserDuration).SetEase(Ease.Linear).OnPlay
            (
                () => laser.DOMove(dir * 0.5f, laserDuration).SetRelative().SetEase(Ease.Linear).OnComplete
                (
                    () => {
                        if (hit.collider.TryGetComponent(out LaserObject _laser))
                        {
                            _laser.hitLaser(dir);
                            StartCoroutine("IclearLasers",LaserClearDelay);
                        }
                    }
                )
            );

        

        lasers.Add(laser);

    }

    public void shootLaser(Vector3 origin, Vector3 target)
    {
        //Debug.Log(target);

        var laser = Instantiate(Laser).transform;
        laser.SetParent(transform);

        var dir = target - origin;

        //laser.position = origin + dir * 0.5f + Vector3.up* laserOffset;
        //Debug.Log(laser.position);
        var i = dir.x + dir.z;
        //laser.localScale = new Vector3(laser.localScale.x, laser.localScale.y, Mathf.Abs(i));



        Vector3 angle = new(0, Vector3.SignedAngle(Vector3.forward, dir.normalized, Vector3.up), 0);
        //Debug.Log(angle);

        laser.localRotation = Quaternion.Euler(angle);
        //laser.gameObject.SetActive(false);

        laser.position = origin + Vector3.up * laserOffset;
        //laser.DOMove(origin + dir * 0.5f + Vector3.up * laserOffset, laserDuration).SetSpeedBased();

        laser.localScale = Vector3.one * 0.1f;
        laser.DOScale(new Vector3(laser.localScale.x, laser.localScale.y, Mathf.Abs(i)), laserDuration).SetEase(Ease.Linear).OnPlay
            (
                () => laser.DOMove(dir * 0.5f, laserDuration).SetRelative().SetEase(Ease.Linear).OnComplete
                (
                    () => 
                            StartCoroutine("IclearLasers", LaserClearDelay))
                        
                    
                
            );



        lasers.Add(laser);

    }

    public void LasersClear(float delay)
    {
        foreach (var t in lasers)
        {
            t.GetComponent<MeshRenderer>().material.DOFade(0, delay).SetEase(@ease).OnComplete(() => Destroy(t.gameObject));
            //Destroy(t.gameObject);
        }

        lasers.Clear();
    }

    IEnumerator IclearLasers(float delay)
    {
        LasersClear(delay);
        yield return null;
    }

    void stageReset()
    {
        foreach (var t in lasers)
        {
            t.DOKill();
            Destroy(t.gameObject);
        }

        lasers.Clear();
    }

}


