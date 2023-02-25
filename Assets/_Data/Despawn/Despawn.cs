using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Class nay dung de xoa vien dan, neu nhu vien dan do bay cach xa camera 70m thi xoa
//abstract la class k ro rang, chua duoc dinh nghia se lam cong viec gif
//Despawn co tac dung la dua obj do tro lai pool sau khi 1 khoang time hoac distance
public abstract class Despawn : ClassBehaviour 
{

    protected virtual void FixedUpdate()
    {
        this.Despawning(); 
    }

    protected virtual void Despawning()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObject();
    }

    public virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }

    protected abstract bool CanDespawn();
}
