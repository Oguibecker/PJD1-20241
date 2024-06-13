using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyTransformController : TransformController
{
    protected Rigidbody2D rb;
    
    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    
    }
}
