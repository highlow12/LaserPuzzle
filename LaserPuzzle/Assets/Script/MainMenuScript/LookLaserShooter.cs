using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class LookLaserShooter : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    Vector2 mousepos;
    float delta = 0;

    Vector2 target, mouse;
    float angle;

    public Canvas canvas;
    Vector2 mousePosition; // 마우스 좌표
    Vector2 localPosition; // 변환된 canvas내 좌표
    //[출처] 유니티 - 마우스 좌표를 canvas내 좌표로 변환|작성자 펭순이

    RectTransform rt;

    private void Start()
    {
         rt = canvas.transform as RectTransform;
        


    }
    void Update()
    {
        mousepos = Input.mousePosition;

        //delta = - Vector2.SignedAngle( Vector2.up, mousepos);

        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, delta));

        transform.LookAt(mousepos);

        
    }
    private void LateUpdate()
    {
        //transform.rotation = Quaternion.Euler(new(0, 0, transform.rotation.x));
    }
}
