using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerEquipmentManager playerEquipManager;
    public string itemName;
    public GameObject itemContainer;
    public Transform weaponHold;
    public int itemID;

    int previousID;
    bool isCreated;
    bool destroyPrev;

    private WeaponAbilities currentWeapon;
    public Animation anim;
    private void Start()
    {
        playerEquipManager = PlayerEquipmentManager.Instance;
    }
    private void Update()
    {
        WeaponsCheck();
        WeaponsModelUpdate();
        Ultimate();
        EquipWeaponFX(itemContainer.GetComponent<WeaponAbilities>());
    }
    public void WeaponsCheck()
    {
        itemName = playerEquipManager.ItemsList[itemID].itemName;
        itemContainer = playerEquipManager.ItemsList[itemID].itemContainer;
        if (previousID != itemID)
        {
            previousID = itemID;
            isCreated = true;
            destroyPrev = true;
        }
    }

    public void EquipWeaponFX(WeaponAbilities weapon)
    {
        currentWeapon = weapon; 
    }
    public void Ultimate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            currentWeapon.Ultimate();
        }
    }
    public void WeaponsModelUpdate()
    {
        if(isCreated)
        {
            GameObject weapon = Instantiate(itemContainer, weaponHold.transform);
            weapon.transform.SetParent(weaponHold.transform);
            isCreated = false;
            if(destroyPrev)
            {
                var prevWeapon = itemContainer.transform.GetChild(0);
                Destroy(prevWeapon);
                destroyPrev = false;
            }
        }
    }

}
