using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    public Transform laser;  // ������ ������Ʈ�� �����մϴ�.
    public float speed = 5f;  // �������� �̵� �ӵ��� �����մϴ�.

    void Start()
    {
        if (!laser)
        {
            Debug.LogError("Laser object not assigned.");
            return;
        }
    }

    void Update()
    {
        if (Camera.main == null)
        {
            Debug.LogError("Main camera not found.");
            return;
        }

        // ���콺 ��ġ�� �����ɴϴ�.
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.z = laser.position.z;  // ���콺 ��ǥ�� z���� ������ ������Ʈ�� z���� �����ϰ� �����մϴ�.

        // �������� ���̸� ���콺 ��ġ�� ���� �����մϴ�.
        Vector3 direction = mouseWorldPosition - laser.position;
        float distance = direction.magnitude;
        laser.localScale = new Vector3(laser.localScale.x, distance, laser.localScale.z);

        // �������� ������ ���콺 ��ġ�� ���� �����մϴ�.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        laser.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
