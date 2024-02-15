using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager instance;

    public GameObject StageUI;
    public GameObject MenuUI;
    public GameObject ClearUI;

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

    public static UIManager Instance
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
    public void SetClaerUI(bool state)
    {
        ClearUI.SetActive(state);
        //ClearUI.GetComponent<ClearUIScript>().showClearUI();
    }
    public void SetStageUI(bool state)
    {
        StageUI.SetActive(state);
        //ClearUI.GetComponent<ClearUIScript>().showClearUI();
    }
    public void SetMenuUI(bool state)
    {
        MenuUI.SetActive(state);
        //ClearUI.GetComponent<ClearUIScript>().showClearUI();
    }

}
