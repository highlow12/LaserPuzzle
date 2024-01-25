using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootButtenScript : MonoBehaviour
{
    public void shootButten()
    {
        GameManager.Instance.StageReset();
        GameManager.Instance.laserStart();
    }
}
