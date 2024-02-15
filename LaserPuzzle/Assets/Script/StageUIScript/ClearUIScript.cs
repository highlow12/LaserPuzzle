using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearUIScript : MonoBehaviour
{
    public GameObject ClearUI;

    

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
        SceneManager.LoadScene(GameManager.Instance.NextStage);
    }

    public void tryAgain()
    {
        hideClearUI();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        AudioManager.Instance.PlaySFX(AudioManager.Sfx.Click);
    }

    
}