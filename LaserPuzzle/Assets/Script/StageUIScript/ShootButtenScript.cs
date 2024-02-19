using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootButtenScript : MonoBehaviour
{
    public void shootButten()
    {
        if (GameManager.Instance.Remainchance >= 0)
        {
            Debug.Log("shoot");
            GameManager.Instance.StageReset();
            GameManager.Instance.laserStart();
        }
    }
}
