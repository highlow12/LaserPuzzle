using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    public LineRenderer laserLineRenderer;

    void Start()
    {
        // 레이저 포인터의 위치를 화면 중앙 아래로 설정
        Vector3 screenCenterBottom = new Vector3(Screen.width / 2, 50);
        transform.position = Camera.main.ScreenToWorldPoint(screenCenterBottom);
    }

    void Update()
    {
        // 마우스의 스크린 좌표를 월드 좌표로 변환
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = transform.position.z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // 레이저 빛의 시작점과 끝점을 설정
        laserLineRenderer.SetPosition(0, transform.position);
        laserLineRenderer.SetPosition(1, worldPosition);
    }
}
