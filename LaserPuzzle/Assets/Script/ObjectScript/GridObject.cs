using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class GridObject : MonoBehaviour
{
    public bool canMove = false;
    public bool isSelected = false;

    Outline outline;

    public Color outSelectColor = Color.white;
    public Color onSelectColor = Color.green;

    public float[] snapAngles = { 0f, 90f, 180f, 270f };

    private void Awake()
    {
        if (!canMove)
        {
            isSelected = false;
        }

        outline = GetComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        //outline.enabled = false;
        outline.OutlineColor = outSelectColor;
    }

    protected void keyboardMove()
    {
        if (isSelected && canMove)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position += transform.forward;
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.Rotate(0, 90, 0);
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position -= transform.forward;
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Rotate(0, -90, 0);
            }

            
        }
    }

    

    protected void gridSnap()
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x),0, Mathf.Round(transform.position.z));
    }

    protected void angleSnap()
    {
        float currentAngle = transform.eulerAngles.y;

        // 스냅할 각도 값들
        

        // 각도 스냅 로직
        float closestSnapAngle = snapAngles[0];
        float minDifference = Mathf.Abs(currentAngle - snapAngles[0]);

        foreach (float snapAngle in snapAngles)
        {
            float angleDifference = Mathf.Abs(currentAngle - snapAngle);

            if (angleDifference < minDifference)
            {
                minDifference = angleDifference;
                closestSnapAngle = snapAngle;
            }
        }

        // 오브젝트를 가장 가까운 스냅 각도로 회전시킴
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, closestSnapAngle, transform.eulerAngles.z);
    }

    protected virtual void Update()
    {
        gridSnap();
        angleSnap();
        keyboardMove();
    }

    public void OnSelected()
    {
        //outline.enabled = true;
        outline.OutlineColor = onSelectColor;
        outline.OutlineWidth = 5;

        isSelected = true;
    }

    public void OutSelected()
    {
        //outline.enabled = false;
        outline.OutlineColor = outSelectColor;
        outline.OutlineWidth = 1;

        isSelected = false;
    }

    protected void DragAndDropMove()
    {
        if (isSelected && canMove)
        {
            //나중에 구현
        }
    }
}