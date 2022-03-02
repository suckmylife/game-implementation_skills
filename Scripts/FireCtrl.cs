using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    private GameObject bullet;
    private Transform firePos;

    private void Awake()
    {
        //bullet = (GameObject)Resources.Load("Prefabs/Bullet");
        //bullet = Resources.Load("Prefabs/Bullet") as GameObject;
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
        firePos = GameObject.FindWithTag("FirePos").transform;        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Fire();
            BulletManager.instance.Fire(firePos);
        }
    }

    private void Fire()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }
}
