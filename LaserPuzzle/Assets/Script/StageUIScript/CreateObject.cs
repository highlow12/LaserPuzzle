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

    void Start()
    {
        switch (objectPrefab.name)
        {
            case "LaserMirrorModel":
                i = 0;
                break;
            case "LaserHalfMirrorModel":
                i = 1;
                break;
            default:
                break;
        }
    }
    int i = 0;
    public void CreateObjectOnClick()
    {
        InstantiateObject(createposition);
    }

    void InstantiateObject(Vector3 position)
    {
        if (objectPrefab != null)
        {
            

            if (0 != GameManager.Instance.mirrors[i])
            {
                if (!Physics.SphereCast(position + Vector3.up * 2, 0.5f, Vector3.down, out var _, 1))
                {
                    //Debug.Log(hit.transform.name);

                    var init = Instantiate(objectPrefab, position, Quaternion.identity);
                    init.SetActive(true);
                    init.GetComponent<GridObject>().canMove = true;

                    GameManager.Instance.SetNowSelectedObject(init.transform);

                    GameManager.Instance.mirrors[i]--;
                }
                else
                {
                    Debug.Log("Remove object");
                }
            }
            else
            {
                Debug.Log("no remain obj");
            }
        }
    }

}
        