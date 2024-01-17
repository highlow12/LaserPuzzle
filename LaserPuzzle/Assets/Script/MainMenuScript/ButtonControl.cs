using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    public GameObject myImage;

    public void ToggleImage()
    {
        if (myImage != null)
        {
            myImage.SetActive(!myImage.activeSelf);
        }
    }
}
