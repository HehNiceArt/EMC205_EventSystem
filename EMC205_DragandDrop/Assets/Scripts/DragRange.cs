using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRange : MonoBehaviour
{
    public float gizmoRange;
    public GameObject player;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.transform.position, gizmoRange);
    }
}
