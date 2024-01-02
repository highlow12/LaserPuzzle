using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateObject : MonoBehaviour
{
    public GameObject objectPrefab; 
    public Button createObject; 

    //void Start()
    //{
    //    createObject.onClick.AddListener(CreateObjectOnClick);
    //}

    public void CreateObjectOnClick()
    {
        InstantiateObject(Vector3.zero);
    }

    void InstantiateObject(Vector3 position)
    {
        if (objectPrefab != null)
        {
            Instantiate(objectPrefab, position, Quaternion.identity);
        }
    }
}