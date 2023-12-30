using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    public LineRenderer laserLineRenderer;

    void Start()
    {
        // ������ �������� ��ġ�� ȭ�� �߾� �Ʒ��� ����
        Vector3 screenCenterBottom = new Vector3(Screen.width / 2, 50);
        transform.position = Camera.main.ScreenToWorldPoint(screenCenterBottom);
    }

    void Update()
    {
        // ���콺�� ��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = transform.position.z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // ������ ���� �������� ������ ����
        laserLineRenderer.SetPosition(0, transform.position);
        laserLineRenderer.SetPosition(1, worldPosition);
    }
}
