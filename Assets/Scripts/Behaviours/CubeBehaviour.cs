using System;
using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 screenPoint;
    private Vector3 offset;
    private bool isDragable = true;
    private CubeModel model;
    
    void OnMouseDown()
    {
        if(isDragable)    // Only do if IsDraggable == true
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
         
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }

    public void setModel(CubeModel model)
    {
        this.model = model;
        Debug.Log(model.cubeValue);
    }

    public CubeModel getModel()
    {
        return this.model;
    }
     
    void OnMouseDrag()
    {
        if(isDragable)    // Only do if IsDraggable == true
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z); // hardcode the y and z for your use
             
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = new Vector3(Mathf.Clamp(curPosition.x, -3.45f, 3.45f), transform.position.y, transform.position.z);
        }
    }

    private void OnMouseUp()
    {
        if (isDragable)
        {
            isDragable = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(0,0,25f), ForceMode.Impulse);
            App.gameManager.onCubeReleased.Invoke();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cube")
        {
            App.gameManager.onCollisonEvent.Invoke(new [] {this.gameObject, other.gameObject});
        }
    }
}
