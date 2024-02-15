using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ret : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ret_()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Sfx.Click);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
