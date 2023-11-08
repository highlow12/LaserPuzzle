using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPortalIn : MonoBehaviour
{
    // 이 포털과 연결된 LaserPortalOut 인스턴스
    public LaserPortalOut connectedPortal;

    // 이 포털이 플레이어에 의해 조작 가능한지 여부
    public bool isOperable;

    // 이 포털이 현재 플레이어에 의해 선택된 상태인지 여부
    public bool isSelected;

    // 이 포털의 그리드 상 위치
    private Vector3 gridPosition;

    // 이 포털의 y축 회전 각도
    private float rotationY;

    // 이 포털의 회전 각도 스냅값
    private float snapAngle = 90f;

    // 이 포털의 이동 속도
    private float moveSpeed = 1f;

    // 이 포털의 회전 속도
    private float rotationSpeed = 90f;

    private void Update()
    {
        // 선택 상태일 경우
        if (isSelected)
        {
            HandleMovement(); // 이동 처리
            SnapToGrid(); // 그리드에 스냅 처리
            SnapRotation(); // 회전 각도에 스냅 처리
        }
    }

    private void HandleMovement()
    {
        // 키보드 입력에 따른 이동과 회전 처리
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
        transform.position += move;

        if (Input.GetKey(KeyCode.Q))
        {
            rotationY -= rotationSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rotationY += rotationSpeed * Time.deltaTime;
        }
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            // 레이저를 연결된 포털로 전송
            connectedPortal.ReceiveLaser(other.gameObject);
        }
    }

    private void OnMouseDown()
    {
        // 마우스 클릭 시 선택 상태로 변경
        isSelected = true;
    }

    private void OnMouseDrag()
    {
        // 마우스 드래그 시 포털 위치를 마우스 위치에 맞춤
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 20; // 카메라와의 거리
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void OnMouseUp()
    {
        // 마우스 클릭이 끝나면 선택 상태 해제
        isSelected = false;
    }

    private void SnapToGrid()
    {
        // 그리드에 스냅: 현재 위치를 가장 가까운 그리드 위치로 변경
        transform.position = new Vector3(Mathf.Round(transform.position.x),
                                         transform.position.y,
                                         Mathf.Round(transform.position.z));
    }

    private void SnapRotation()
    {
        // 회전 각도에 스냅: 현재 회전 각도를 가장 가까운 스냅 각도로 변경
        rotationY = Mathf.Round(rotationY / snapAngle) * snapAngle;
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
