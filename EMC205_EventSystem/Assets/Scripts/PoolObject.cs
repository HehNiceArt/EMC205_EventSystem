using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public static PoolObject SharedInstance;
    public List<GameObject> PoolObjects;
    public GameObject ObjectsToPool;
    public int AmountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        //Create the pool object
        PoolObjects = new List<GameObject>();
        GameObject temp;

        for (int i = 0; i < AmountToPool; i++)
        {
            temp = Instantiate(ObjectsToPool);
            temp.SetActive(false);
            PoolObjects.Add(temp);
        }
    }
    public  GameObject GetPooledObject()
    {
        for(int i = 0;i < AmountToPool;i++)
        {
            if (!PoolObjects[i].activeInHierarchy)
            {
                return PoolObjects[i];
            }
        }
        return null;
    }
}
