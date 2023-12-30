using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    public Transform laser;  // 레이저 오브젝트를 참조합니다.
    public float speed = 5f;  // 레이저의 이동 속도를 설정합니다.

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

        // 마우스 위치를 가져옵니다.
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.z = laser.position.z;  // 마우스 좌표의 z값은 레이저 오브젝트의 z값과 동일하게 설정합니다.

        // 레이저의 길이를 마우스 위치에 따라 변경합니다.
        Vector3 direction = mouseWorldPosition - laser.position;
        float distance = direction.magnitude;
        laser.localScale = new Vector3(laser.localScale.x, distance, laser.localScale.z);

        // 레이저의 방향을 마우스 위치에 따라 변경합니다.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        laser.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
