using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class texttyping : MonoBehaviour
{
    public Text text;
    string str;
    public float @time = 1;
    private void Awake()
    {
        //text = GetComponent<Text>();
        str= text.text;
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        //text.DOKill();
        //text = null;
        //text.DOText(str, @time).SetEase(Ease.Linear);
        StartCoroutine(typing());
    }

    IEnumerator typing()
    {
        text.text = null;
        for (int i = 0; i < str.Length; i++)
        {
            text.text += str[i];
            yield return new WaitForSeconds(time / str.Length);
        }
    }
}
