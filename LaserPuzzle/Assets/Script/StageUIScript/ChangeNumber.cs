using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeNumber : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public int number = 5;

    void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();

        if (textField != null)
        {
            textField.text = "Remain chance: " + number;
        }
        else
        {
            Debug.LogError("Error1");
        }
    }

    public void ReduceNumber()
    {
        //textField = GetComponent<Text>();

        if (textField != null)
        {
            number--;
            textField.text = "Remain chance: " + number;
        }
        else
        {
            Debug.LogError("Error2");
        }
    }
}