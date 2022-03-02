using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAnim
{
    public AnimationClip idle;
    public AnimationClip runF;
    public AnimationClip runB;
    public AnimationClip runL;
    public AnimationClip runR;
}

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotSpeed = 80.0f;
    public float jumpPower = 100.0f;

    public PlayerAnim playerAnim;    

    private float h = 0.0f;
    private float v = 0.0f;
    private float r = 0.0f;

    private bool isJump = false;

    private Rigidbody rigidbody;
    private Animation animation;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        if(Input.GetKeyDown(KeyCode.Space) && !isJump)
        {            
            if(rigidbody != null)
            {
                rigidbody.AddForce(Vector3.up * jumpPower);
                isJump = true;
            }
        }

        Vector3 dir = new Vector3(h, 0, v);
                
        if(dir.magnitude > 1.0f)
            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
        else
            transform.Translate(dir * moveSpeed * Time.deltaTime);

        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime * r);

        if(v >= 0.1f)
        {
            //            animation.CrossFade("RunF")
            animation.CrossFade(playerAnim.runF.name, 0.3f);
        }else if(v <= -0.1f)
        {
            animation.CrossFade(playerAnim.runB.name, 0.3f);
        }else if(h >= 0.1f)
        {
            animation.CrossFade(playerAnim.runR.name, 0.3f);
        }
        else if (h <= -0.1f)
        {
            animation.CrossFade(playerAnim.runL.name, 0.3f);
        }else
        {
            animation.CrossFade(playerAnim.idle.name, 0.3f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }
}
