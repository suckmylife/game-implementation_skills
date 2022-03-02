﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float damage = 20.0f;
    public float speed = 1000.0f;

    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponentInChildren<Rigidbody>();
    }

    private void Start()
    {
        rigidbody.AddForce(transform.forward * speed);
    }
}
