using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    private Animation animation;

    private float h = 0.0f;
    private float v = 0.0f;

    private void Awake()
    {
        animation = GetComponent<Animation>();        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        if (dir.magnitude > 0)
            animation.CrossFade("Running", 0.2f);
        else
            animation.CrossFade("Idle", 0.2f);
    }
}
