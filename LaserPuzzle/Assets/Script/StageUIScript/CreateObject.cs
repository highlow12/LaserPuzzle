using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Image;

public class CreateObject : MonoBehaviour
{
    public GameObject objectPrefab;
    public Button createObject;
    public Vector3 createposition = new(3, 0, 8);

    //void Start()
    //{
    //    createObject.onClick.AddListener(CreateObjectOnClick);
    //}

    public void CreateObjectOnClick()
    {
        InstantiateObject(createposition);
    }

    void InstantiateObject(Vector3 position)
    {
        if (objectPrefab != null)
        {

            if (false == Physics.SphereCast(position + Vector3.up * 2, 0.5f, Vector3.down, out var hit, 1))
            {
                //Debug.Log(hit.transform.name);

                var init = Instantiate(objectPrefab, position, Quaternion.identity);
                init.GetComponent<GridObject>().canMove = true;

                GameManager.Instance.SetNowSelectedObject(init.transform);
            }
            else
            {
                Debug.Log("Remove object");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Gizmos�� ���� ���� (��: ������)
        Gizmos.color = Color.red;

        // ���Ǿ� ĳ��Ʈ�� ���� ��ġ���� ���̸� �׸��� ����
        Gizmos.DrawRay(createposition, Vector3.up * 1);

        // ���Ǿ� ĳ��Ʈ�� ���� ��ġ���� ���Ǿ� ����� Gizmo �׸���
        Gizmos.DrawWireSphere(createposition + Vector3.up * 1, 0.5f);
    }
}
        