using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;

    public Action<Vector3, Vector3> LaserStartShoot; //레이저 슈터가 레이저를 쏘게 하는 델리게이트

    int allReceverNum = 0;
    int laserRecevedNum = 0;

    GameObject nowSelectedObject = null;

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

    public static GameManager Instance 
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

    public void addRecever()
    {
        allReceverNum++;
    }

    public void laserReceve()
    {
        laserRecevedNum++;
        
    }

    public void laserStart()//이 함수를 실행시키면 모든 레이저 슈터가 레이저를 발사한다
    {
        LaserStartShoot(Vector3.zero, Vector3.zero);
    }

    void clearGame()
    {
        Debug.Log("GameClear");
    }

    private void Update()
    {
        if (laserRecevedNum == allReceverNum)
        {
            
            clearGame();
            laserRecevedNum++;
        }
        
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.TryGetComponent<GridObject>(out var @object))
                {
                    Debug.Log("터치된 오브젝트: " + hit.transform.name);

                    if (nowSelectedObject != @object.gameObject)
                    {
                        if (nowSelectedObject != null)
                            nowSelectedObject.GetComponent<GridObject>().OutSelected();
                        nowSelectedObject = null;

                        nowSelectedObject = @object.gameObject;
                        nowSelectedObject.GetComponent<GridObject>().OnSelected();
                    }
                }
                else
                {
                    if(nowSelectedObject != null)
                        nowSelectedObject.GetComponent<GridObject>().OutSelected();
                    nowSelectedObject = null;
                }
            }
        }
    }

}
