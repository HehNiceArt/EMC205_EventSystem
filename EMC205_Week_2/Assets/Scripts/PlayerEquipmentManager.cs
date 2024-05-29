using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Items
{
    public string itemName;
    public string itemDescription;
    public int itemID;
    public GameObject itemContainer;
}
public class PlayerEquipmentManager : MonoBehaviour
{
    //[field: SerializeField]
    //public List<Items> items { get; private set; }
    [SerializeField]
    private List<Items> itemsList = new List<Items>();
    public List<Items> ItemsList { get { return itemsList; } }

    public static PlayerEquipmentManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
