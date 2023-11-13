using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;

    int allReceverNum = 0;
    int laserRecevedNum = 0;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance 
    { 
        get 
        { 
            if (instance == null) 
            {
                return null;
            }
            else
            {
                return instance;
            }
        } 
    }

    public void addRecever()
    {
        allReceverNum++;
    }

    public void laserReceve()
    {
        laserRecevedNum++;
        
    }

    void clearGame()
    {
        Debug.Log("GameClear");
    }

    private void Update()
    {
        if (laserRecevedNum == allReceverNum)
        {
            
            clearGame();
            laserRecevedNum++;
        }
        
    }
}
