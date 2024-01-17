using UnityEngine;

public class PanelControl : MonoBehaviour
{
    public GameObject myPanel; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClosePanel();
        }
    }

    public void OnButtonClick()
    {
        if (myPanel != null)
        {
            myPanel.SetActive(false);
        }
    }

    void ClosePanel()
    {
        if (myPanel != null)
        {
            myPanel.SetActive(false);
        }
    }
}
