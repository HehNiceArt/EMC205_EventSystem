using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public bool isKnife, isAxe, isGun;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isKnife){EventsManager.Instance.KnifePortal();}
            if (isAxe) {EventsManager.Instance.AxePortal();}
            if (isGun) {EventsManager.Instance.GunPortal();}
            
        }
    }
}
