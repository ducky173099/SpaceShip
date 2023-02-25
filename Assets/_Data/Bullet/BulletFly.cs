using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : ParentFly
{
    //[SerializeField] protected int movespeed = 1; // toc do
    //[SerializeField] protected Vector3 direction = Vector3.right; // huong bay
    //private void FixedUpdate()
    //{
    //transform.parent.Translate(this.direction * this.movespeed * Time.deltaTime);
    //}

    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 7f;
    }
}
