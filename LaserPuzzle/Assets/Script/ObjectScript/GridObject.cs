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
                //-x,-z로 이동
                transform.position = transform.position + Vector3.left + Vector3.back;
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //+x으로 이동
                transform.position = transform.position + Vector3.right;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                //+x,+z로 이동
                transform.position = transform.position + Vector3.right + Vector3.forward;
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                //+z으로 이동
                transform.position = transform.position + Vector3.forward;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.localEulerAngles = transform.localEulerAngles + new Vector3(0, 90, 0);
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                transform.localEulerAngles = transform.localEulerAngles + new Vector3(0, -90, 0);
            }
        }
    }

    protected void DragAndDropMove() 
    {
        if (isSelected && canMove)
        {
            //나중에 구현
        }
    }

    protected void gridSnap()
    {
        transform.position = 
            new Vector3(Mathf.Round(transform.position.x),0, Mathf.Round(transform.position.z));
    }

    protected void angleSnap()
    {
        var angle = transform.eulerAngles.y;

        if (angle < 45 || angle >= 315)
        {
            angle = 0;
        }
        else if (angle < 135 || angle >= 45)
        {
            angle = 90;
        }
        else if (angle < 225 || angle >= 135)
        {
            angle = 180;
        }
        else if (angle < 315 || angle >= 225)
        {
            angle = 270;
        }

        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    protected virtual void Update()
    {
        gridSnap();
        //angleSnap();
        keyboardMove();
    }

    public void OnSelected()
    {
        //outline.enabled = true;
        outline.OutlineColor = onSelectColor;
    }

    public void OutSelected()
    {
        //outline.enabled = false;
        outline.OutlineColor = outSelectColor;
    }

}