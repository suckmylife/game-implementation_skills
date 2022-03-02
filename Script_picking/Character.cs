using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotSpeed = 50.0f;

    private float h = 0.0f;
    private float v = 0.0f;

    private bool isAttack = false;

    private Animator animator;
    private AnimatorStateInfo stateInfo;

    private int attackHash = Animator.StringToHash("Attack");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttack)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        }

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * v);
        transform.Rotate(Vector3.up * h* rotSpeed * Time.deltaTime);

        animator.SetFloat("Speed", v);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //animator.CrossFade("Attack", 0.2f);
            animator.SetTrigger("Attack");
            isAttack = true;
            h = 0.0f;
            v = 0.0f;
            
        }
        /*
        if(isAttack)
        {
            stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            if(stateInfo.shortNameHash == attackHash)
            {
                //print(stateInfo.normalizedTime);
                if(stateInfo.normalizedTime >= 0.9f)
                {
                    isAttack = false;
                }
            }
        }*/
    }

    public void SetAttack(bool isAttack)
    {
        this.isAttack = isAttack;
    }
}
