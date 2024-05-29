using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalUpdateManager : MonoBehaviour
{
    public List<GameObject> Weapons = new List<GameObject>();
    int activeIndex;
    private void Start()
    {
        foreach (GameObject weapon in Weapons)
        {
            weapon.SetActive(false);
        }
    }

    void ToggleWeapons(int index)
    {
        for(int i = 0; i < Weapons.Count; i++)
        {
            //toggle the activation state base on the provided index
            Weapons[i].SetActive(i == index);
        }
    }
    private void OnEnable()
    {
        EventsManager.OnAxePortal += AxeEnabled;
        EventsManager.OnKnifePortal += KnifeEnabled;
        EventsManager.OnGunPortal += GunEnabled;
    }

    private void KnifeEnabled()
    {
        ToggleWeapons(1);
        Debug.Log("Knife");
    }

    private void GunEnabled()
    {
        ToggleWeapons(2); 
        Debug.Log("Gun");
    }

    private void AxeEnabled()
    {
        ToggleWeapons(0); 
        Debug.Log("Axe");
    }

}
