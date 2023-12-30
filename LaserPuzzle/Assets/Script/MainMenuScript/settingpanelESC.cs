using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingpanelESC : MonoBehaviour
{
    public GameObject settingPanel;  // 설정 패널을 참조하는 변수

    void Start()
    {
        settingPanel.SetActive(false);  // 게임이 시작될 때 설정 패널 비활성화
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingPanel.SetActive(false);  // 설정 패널 비활성화
        }
    }
}
