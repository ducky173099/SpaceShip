using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : ClassBehaviour
{
    [SerializeField] protected float moveSpeed = 1f; // toc do
    [SerializeField] protected Vector3 direction = Vector3.right; // huong bay

    void Update()
    {
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }
}
