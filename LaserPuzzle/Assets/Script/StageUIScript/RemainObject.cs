using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RemainObject : MonoBehaviour
{
    public TextMeshProUGUI objectField;

    public int readMirror = 0;// 0 = �ſ�, 1 = �ݰſ�
    int Object = 3;

    void Start()
    {
        objectField = GetComponent<TextMeshProUGUI>();
        
        objectField.text = "" + GameManager.Instance.mirrors[readMirror];
    }

    private void Update()
    {
        objectField.text = "" + GameManager.Instance.mirrors[readMirror];
    }

    public void ReduceObject()
    {
        if (objectField != null)
        {
            Object--;
            objectField.text = "" + Object;
        }
        else
        {
            Debug.LogError("Error2");
        }
    }
}