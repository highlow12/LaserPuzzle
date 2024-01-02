using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneChange : MonoBehaviour
{
    public GameObject MenuUI;

    void Start()
    {
        MenuUI.SetActive(false);
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
        MenuUI.SetActive(true);
    }

    public void HideMenu()
    {
        MenuUI.SetActive(false);
    }
}