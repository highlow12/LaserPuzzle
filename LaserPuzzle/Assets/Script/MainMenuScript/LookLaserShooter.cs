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
    Vector2 mousePosition; // ���콺 ��ǥ
    Vector2 localPosition; // ��ȯ�� canvas�� ��ǥ
    //[��ó] ����Ƽ - ���콺 ��ǥ�� canvas�� ��ǥ�� ��ȯ|�ۼ��� �����

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
