using UnityEngine;
using UnityEngine.UI;

public class LaserPointer : MonoBehaviour
{
    public RectTransform laserPointer; // ������ �������� RectTransform
    public RectTransform laser; // �������� RectTransform
    public Canvas canvas; // Canvas ������Ʈ

    void Update()
    {
        // ���콺 ��ġ�� Canvas�� �°� ��ȯ
        Vector2 localMousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out localMousePosition);

        // ������ �������� ��ġ�� ���콺 ��ġ�� ���� ����
        laserPointer.anchoredPosition = localMousePosition;

        // �������� ��ġ�� ������ �������� �߾ӿ� ����
        laser.anchoredPosition = laserPointer.anchoredPosition;

        // �������� ���̸� ���콺 ��ġ�� ���� ����
        Vector2 direction = localMousePosition - laserPointer.anchoredPosition;
        float distance = direction.magnitude;
        laser.sizeDelta = new Vector2(laser.sizeDelta.x, distance);

        // �������� ������ ���콺 ��ġ�� ���� ����
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        laser.rotation = Quaternion.Euler(0, 0, angle);
    }
}
