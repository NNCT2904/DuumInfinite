using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Drag : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld;
    public Transform borderTopRight;
    public Transform borderDownLeft;

    void Update()
    {
        if (isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            float top = borderTopRight.position.x;
            float bottom = borderDownLeft.position.x;
            float left = borderDownLeft.position.y;
            float right = borderTopRight.position.y;
            if (mousePos.x <= top && mousePos.x >= bottom && mousePos.y >= left && mousePos.y <= right)
            {
                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY);
            }
            else
            {
                isBeingHeld = false;
            }
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);



            this.startPosX = mousePos.x - this.transform.localPosition.x;
            this.startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;

        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
}
