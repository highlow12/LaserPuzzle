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

    public GameObject arrowUi = null;

    public string NextStage = "";

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
        Debug.Log(allReceverNum);
    }

    public void laserReceve()
    {
        laserRecevedNum++;
        Debug.Log(laserRecevedNum);
    }

    public void laserStart()//�� �Լ��� �����Ű�� ��� ������ ���Ͱ� �������� �߻��Ѵ�
    {
        LaserStartShoot(Vector3.zero, Vector3.zero);
    }

    public void SetNowSelectedObject(Transform hit)
    {
        if (hit.transform.TryGetComponent<GridObject>(out var @object))
        {
            //Debug.Log("��ġ�� ������Ʈ: " + hit.transform.name);

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
            ReleseNowSelectedobject();
        }
    }

    private void ReleseNowSelectedobject()
    {
        if (!nowSelectedObject.GetComponent<GridObject>().cantOutSelect)
        {
            if (nowSelectedObject != null)
                nowSelectedObject.GetComponent<GridObject>().OutSelected();

            nowSelectedObject = null;
        }
    }

    void clearGame()
    {
        Debug.Log("GameClear");
        UIManager.Instance.ClearUI.SetActive(true);
        UIManager.Instance.StageUI.SetActive(false);
        UIManager.Instance.MenuUI.SetActive(false);
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
            
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit))
            {
                SetNowSelectedObject(hit.transform);
            }

            
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ReleseNowSelectedobject();
        }

        if (nowSelectedObject != null)
        {
            arrowUi.transform.position = nowSelectedObject.transform.position;
            arrowUi.transform.rotation = nowSelectedObject.transform.rotation;

            arrowUi.SetActive(true);
        }
        else
        {
            arrowUi.SetActive(false);
        }
    }
}
