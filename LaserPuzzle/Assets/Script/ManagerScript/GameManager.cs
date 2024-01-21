using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;

    public Action<Vector3, Vector3> LaserStartShoot; //������ ���Ͱ� �������� ��� �ϴ� ��������Ʈ

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

    public void laserStart()//�� �Լ��� �����Ű�� ��� ������ ���Ͱ� �������� �߻��Ѵ�
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
                    Debug.Log("��ġ�� ������Ʈ: " + hit.transform.name);

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
