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

        if(textField == null )
        {
            textField = GetComponent<TextMeshProUGUI>();
        }

        if (textField != null)
        {
            textField.text = "Remain chance: " + GameManager.Instance.Remainchance;
        }
        else
        {
            Debug.LogError("Error1");
        }
    }

    public void ReduceNumber()
    {
        if (textField != null)
        {
            if (GameManager.Instance.Remainchance > 0)
            {
                GameManager.Instance.Remainchance--;
                textField.text = "Remain chance: " + GameManager.Instance.Remainchance;
            }
        }
        else
        {
            Debug.LogError("Error2");
        }
    }
}