using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public Transform BulletSpawnPoint;
    public float Speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject bullet = PoolObject.SharedInstance.GetPooledObject();
            if(bullet != null )
            {
                bullet.transform.position = BulletSpawnPoint.transform.position;
                bullet.transform.rotation = BulletSpawnPoint.transform.rotation;

                bullet.GetComponent<Rigidbody>().velocity = BulletSpawnPoint.forward * Speed;
                bullet.SetActive(true);
            }
        }
    }
}
