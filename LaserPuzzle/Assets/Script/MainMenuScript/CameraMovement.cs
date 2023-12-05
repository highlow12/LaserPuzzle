using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public void MoveToMainCameraPosition()
    {
        // Camera.main�� ���� ���� Ȱ��ȭ�� ���� ī�޶��� ��ġ�� �������� �̵�
        if (Camera.main != null)
        {
            transform.position = Camera.main.transform.position;
            transform.rotation = Camera.main.transform.rotation;
        }
        else
        {
            Debug.LogError("���� ī�޶� ã�� �� �����ϴ�.");
        }
    }
}
