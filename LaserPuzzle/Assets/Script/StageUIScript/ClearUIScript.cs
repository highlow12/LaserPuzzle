using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearUIScript : MonoBehaviour
{
    public GameObject ClearUI;

    void Start()
    {
        ClearUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            hideClearUI();
        }
    }

    public void nextLevel()
    {
        hideClearUI();
        SceneManager.LoadScene(/*�������� ��*/"StageUI");
    }

    public void tryAgain()
    {
        hideClearUI();
        SceneManager.LoadScene(/*�������� ��*/"StageUI");
    }

    public void goMain()
    {
        hideClearUI();
        SceneManager.LoadScene("StartScene");
    }

    public void showClearUI()
    {
        ClearUI.SetActive(true);
    }

    public void hideClearUI()
    {
        ClearUI.SetActive(false);
    }

    
}