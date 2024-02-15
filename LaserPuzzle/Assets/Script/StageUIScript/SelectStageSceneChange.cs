using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectStageSceneChange : MonoBehaviour
{
    public void selectStageSceneChange()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Sfx.Click);
        SceneManager.LoadScene("SelectScene");
    }
}
