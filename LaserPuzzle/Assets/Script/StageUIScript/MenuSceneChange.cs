using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneChange : MonoBehaviour
{
    public GameObject MenuUI;

    void Start()
    {
       // MenuUI = GameObject.Find("MenuUI");
        //MenuUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            ShowMenu();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            HideMenu();
        }
    }

    public void ShowMenu()
    {
        //MenuUI.SetActive(true);
        UIManager.Instance.SetMenuUI(true);
    }

    public void HideMenu()
    {
        UIManager.Instance.SetMenuUI(false);
        //MenuUI.SetActive(false);
    }
}