using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager instance;

    public int poolCount = 50;

    private GameObject bullet;
    private List<GameObject> bulletList = new List<GameObject>();
    private void Awake()
    {
        instance = this;
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
    }    
        
    void Update()
    {
        
    }

    private void CreateBullet()
    {
        for(int i=0; i<poolCount; i++)
        {
            GameObject bulletObj = Instantiate(bullet,
                Vector3.zero, Quaternion.identity);
            bulletObj.SetActive(false);
            bulletList.Add(bulletObj);
        }
    }

    //public void Fire(Vector3 pos, Quaternion rot)
    public void Fire(Transform fireTrans)
    {

    }
}
