using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }
}
