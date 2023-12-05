using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public void MoveToMainCameraPosition()
    {
        // Camera.main을 통해 현재 활성화된 메인 카메라의 위치와 방향으로 이동
        if (Camera.main != null)
        {
            transform.position = Camera.main.transform.position;
            transform.rotation = Camera.main.transform.rotation;
        }
        else
        {
            Debug.LogError("메인 카메라를 찾을 수 없습니다.");
        }
    }
}
