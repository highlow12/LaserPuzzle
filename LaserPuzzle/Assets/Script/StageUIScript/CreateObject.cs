using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateObject : MonoBehaviour
{
    public GameObject objectPrefab; 
    public Button createObject; 
    public Vector3 createposition = new(3,0,8);

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
            Instantiate(objectPrefab, position, Quaternion.identity);
        }
    }
}