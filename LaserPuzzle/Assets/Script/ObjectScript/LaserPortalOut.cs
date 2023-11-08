using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPortalOut : MonoBehaviour
{
    // 플레이어가 조작 가능한지 표시
    public bool isOperable;

    // 플레이어가 현재 선택한 기물인지 표시
    public bool isSelected;

    // 그리드 위치를 저장
    private Vector3 gridPosition;

    // y축 회전 각도를 저장
    private float rotationY;

    // 각도 스냅을 위한 값
    private float snapAngle = 90f;

    // 이동 속도
    private float moveSpeed = 1f;

    // 회전 속도
    private float rotationSpeed = 90f;

    private void Update()
    {
        // 선택된 상태일 때
        if (isSelected)
        {
            HandleMovement(); // 이동/회전 처리
            SnapToGrid(); // 그리드에 스냅 처리
            SnapRotation(); // 회전 각도에 스냅 처리
        }
    }

    private void HandleMovement()
    {
        // 키보드 입력에 따른 이동과 회전 처리
        float moveX = Input.GetAxis("Horizontal"); // 가로 방향 입력값
        float moveZ = Input.GetAxis("Vertical"); // 세로 방향 입력값
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

    private void OnMouseDown()
    {
        // 마우스 클릭 시 선택 상태로 변경
        isSelected = true;
    }

    private void OnMouseDrag()
    {
        // 마우스 드래그 시 포털 위치를 마우스 위치에 맞춤
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10; // 카메라와의 거리
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

    public void ReceiveLaser(GameObject laser)
    {
        // LaserPortalIn에서 전송된 레이저를 받아 처리
        laser.transform.position = transform.position;
        laser.transform.rotation = transform.rotation;
        FireLaser(laser);
    }

    private void FireLaser(GameObject laser)
    {
        // 레이저를 발사하는 로직을 구현 
	// 테스트 안해봐서 이렇게 하는건지 잘 모르겠음
    }
}
