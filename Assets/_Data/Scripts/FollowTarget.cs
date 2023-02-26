using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//FollowTarget nay dung de camera di chuyen theo target (o day la con tau)
public class FollowTarget : ClassBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;

    protected virtual void FixedUpdate()
    {
        this.Following();
    }

    protected virtual void Following()
    {
        if (this.target == null) return;
        //Vi ham nay dc goi trong FixedUpdate nen ta phai dung Time.fixedDeltaTime, con k se dung Time.deltaTime
        transform.position = Vector3.Lerp(transform.position, this.target.position, Time.fixedDeltaTime * this.speed);
    }
}
