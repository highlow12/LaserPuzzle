using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;

    public Action<Vector3, Vector3> LaserStartShoot; //레이저 슈터가 레이저를 쏘게 하는 델리게이트
    public Action StageReset;

    int allReceverNum = 0;
    int laserRecevedNum = 0;

    GameObject nowSelectedObject = null;

    public GameObject arrowUi = null;

    public string NextStage = "";


    public int[] mirrors = new int[2]{ 10, 10 };
    public int Remainchance = 5;
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
    private void Start()
    {
        StageReset += stageReset;

        arrowUi = GameObject.Find("arrow 3dui");

        NextStage = SceneManager.GetActiveScene().name;

        var words = NextStage.Split(' ');

        int num = int.Parse(words[1]);
        num++;

        NextStage = words[0] + " " + num.ToString();


        UIManager.Instance.SetMenuUI(false);
        AudioManager.Instance.PlayBgm();
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

    public void laserStart()//이 함수를 실행시키면 모든 레이저 슈터가 레이저를 발사한다
    {
        StageReset();
        LaserStartShoot(Vector3.zero, Vector3.zero);
    }

    public void SetNowSelectedObject(Transform hit)
    {
        if (hit.transform.TryGetComponent<GridObject>(out var @object))
        {
            //Debug.Log("터치된 오브젝트: " + hit.transform.name);

            if (nowSelectedObject != @object.gameObject)
            {
                if (nowSelectedObject != null)
                    nowSelectedObject.GetComponent<GridObject>().OutSelected();

                nowSelectedObject = null;

                if (@object.GetComponent<GridObject>().canMove) 
                { 
                    nowSelectedObject = @object.gameObject;
                    nowSelectedObject.GetComponent<GridObject>().OnSelected();
                }
            }
        }
        else
        {
            ReleseNowSelectedobject();
        }
    }

    private void ReleseNowSelectedobject()
    {
        if (nowSelectedObject != null)
        {
            if (!nowSelectedObject.GetComponent<GridObject>().cantOutSelect)
            {
                if (nowSelectedObject != null)
                    nowSelectedObject.GetComponent<GridObject>().OutSelected();

                nowSelectedObject = null;
            }
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

    void stageReset()
    {
        Debug.Log("Reset");
        laserRecevedNum = 0;
    }
}
