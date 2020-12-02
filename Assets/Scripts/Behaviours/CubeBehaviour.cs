using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 screenPoint;
    private Vector3 offset;
    public bool IsDragable = true;
     
    void OnMouseDown()
    {
        if(IsDragable)    // Only do if IsDraggable == true
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
         
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }
     
    void OnMouseDrag()
    {
        if(IsDragable)    // Only do if IsDraggable == true
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z); // hardcode the y and z for your use
             
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = new Vector3(Mathf.Clamp(curPosition.x, -3.45f, 3.45f), transform.position.y, transform.position.z);
        }
    }

    private void OnMouseUp()
    {
        if (IsDragable)
        {
            IsDragable = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(0,0,25f), ForceMode.Impulse);
            App.gameManager.onCubeReleased.Invoke();
        }
    }
}
