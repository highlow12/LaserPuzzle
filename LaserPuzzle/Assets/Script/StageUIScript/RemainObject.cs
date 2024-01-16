using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RemainObject : MonoBehaviour
{
    public TextMeshProUGUI objectField;
    public int Object = 3;

    void Start()
    {
        objectField = GetComponent<TextMeshProUGUI>();

        if (objectField == null)
        {
            objectField = GetComponent<TextMeshProUGUI>();
        }

        if (objectField != null)
        {
            objectField.text = "" + Object;
        }
        else
        {
            Debug.LogError("Error1");
        }
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