using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeNumber : MonoBehaviour
{
    public TextMeshProUGUI textMeshProText; // Reference to the TextMeshPro component

    void Start()
    {
        // Example of changing text during startup
        ChangeTextValue("New Text Value");
    }

    // Method to change the text
    void ChangeTextValue(string newText)
    {
        // Check if the TextMeshPro component is assigned
        if (textMeshProText != null)
        {
            // Change the text value
            textMeshProText.text = newText;
        }
        else
        {
            Debug.LogError("TextMeshPro component is not assigned. Please assign it in the Inspector.");
        }
    }
}
