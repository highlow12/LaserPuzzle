using UnityEngine;
using UnityEngine.UI;

public class LaserPointer : MonoBehaviour
{
    public RectTransform laserPointer; // 레이저 포인터의 RectTransform
    public RectTransform laser; // 레이저의 RectTransform
    public Canvas canvas; // Canvas 컴포넌트

    void Update()
    {
        // 마우스 위치를 Canvas에 맞게 변환
        Vector2 localMousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out localMousePosition);

        // 레이저 포인터의 위치를 마우스 위치에 따라 변경
        laserPointer.anchoredPosition = localMousePosition;

        // 레이저의 위치를 레이저 포인터의 중앙에 고정
        laser.anchoredPosition = laserPointer.anchoredPosition;

        // 레이저의 길이를 마우스 위치에 따라 변경
        Vector2 direction = localMousePosition - laserPointer.anchoredPosition;
        float distance = direction.magnitude;
        laser.sizeDelta = new Vector2(laser.sizeDelta.x, distance);

        // 레이저의 방향을 마우스 위치에 따라 변경
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        laser.rotation = Quaternion.Euler(0, 0, angle);
    }
}
