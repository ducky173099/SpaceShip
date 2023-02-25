using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRotate : JunkAbstract
{
    [SerializeField] protected float speed = 9f;

    protected virtual void FixedUpdate()
    {
        this.Rotating(); // Lien tuc lam thay doi goc quay cua thien thach
    }

    protected virtual void Rotating()
    {
        Vector3 eulers = new Vector3(0f, 0f, 1f);

        this.junkCtrl.Model.Rotate(eulers * this.speed * Time.fixedDeltaTime);
    }
}
