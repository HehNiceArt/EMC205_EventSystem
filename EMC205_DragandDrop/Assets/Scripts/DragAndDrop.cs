using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DragAndDrop : MonoBehaviour
{
    public Camera cam;
    public GameObject playerPos;
    public DragRange gizmoRange;
    public UIUpdate uiUpdate;
    private Vector3 screenPoint;
    Vector3 offset;

    bool isPicked = false;

    public float dist;

    private void Update()
    {
        dist = Vector3.Distance(transform.position, gizmoRange.transform.position);
    }
    private void OnMouseDown()
    {
            isPicked = true;
        if(dist <= gizmoRange.gizmoRange)
        {
            screenPoint = cam.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }
    private void OnMouseDrag()
    {
            isPicked = true;
        if(dist <= gizmoRange.gizmoRange)
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = cam.ScreenToWorldPoint(cursorPoint) + offset;
            transform.position = cursorPosition;
        }
    }

    private void OnMouseUp()
    {
        isPicked = false;
    }
    private void OnGUI()
    {
        //GUI elements
        GUI.contentColor = Color.black;
        GUIStyle headStyle = new GUIStyle();
        headStyle.fontSize = 30;
        headStyle.alignment = TextAnchor.MiddleCenter;
        //If the distance is less than the range of the gizmo of the player AND LMB is not pressed/object is not pressed
        if(dist <= gizmoRange.gizmoRange && isPicked == false)
        {
            GUI.Label(new Rect(Screen.width/2, Screen.height/2 + 50, uiUpdate.rectWidth, uiUpdate.rectHeight), "Pick Up", headStyle);
        }
        else if(dist <= gizmoRange.gizmoRange && isPicked == true)
        {
            GUI.Label(new Rect(Screen.width/2, Screen.height/2 + 50, uiUpdate.rectWidth, uiUpdate.rectHeight), "Drop", headStyle);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, playerPos.transform.position);
    }
}
