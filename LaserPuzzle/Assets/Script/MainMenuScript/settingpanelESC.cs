using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingpanelESC : MonoBehaviour
{
    public GameObject settingPanel;  // ���� �г��� �����ϴ� ����

    void Start()
    {
        settingPanel.SetActive(false);  // ������ ���۵� �� ���� �г� ��Ȱ��ȭ
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingPanel.SetActive(false);  // ���� �г� ��Ȱ��ȭ
        }
    }
}
