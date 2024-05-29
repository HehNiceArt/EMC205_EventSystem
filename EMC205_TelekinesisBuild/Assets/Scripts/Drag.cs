using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Drag : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Transform playerHand;

    public Hand hand;

    bool isDragging = false;
    float chargeTime = 0f;
    private void Update()
    {
        RayDrag();
    }
    void RayDrag()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        if (Input.GetMouseButton(0))
        {
            //Drag object at hand
            if (Physics.SphereCast(ray, hand.handRange, out hit, hand.handRange, layerMask))
            {
                hit.collider.transform.position = Vector3.Lerp(hit.transform.position, playerHand.transform.position, time);
                isDragging = true;
                CheckGravity(hit, isDragging);

                chargeTime++;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.SphereCast(ray, hand.handRange, out hit, hand.handRange, layerMask))
            {
                isDragging = false;
                Charge(hit, chargeTime);
                chargeTime = 0;
                CheckGravity(hit, isDragging);
            }
        }
        
    }

    void Charge(RaycastHit hit, float chargeTime)
    {
        float clampedCharge = Mathf.Clamp(chargeTime, 0, 1000);
        hit.rigidbody.AddForce(transform.forward * clampedCharge * 2f, ForceMode.Force);
    }
    void CheckGravity(RaycastHit hit, bool isDragging)
    {
        //checks the gravity
        hit.rigidbody.useGravity = !isDragging;
        Debug.Log("Gravity: " + !isDragging);
    }
}
