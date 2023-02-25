using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDespawn : DespawnByDistance
{
    // khi ma vien da dc despawn, thi no se quay lai poolobject
    // class nay thua ke lai ham DespawnObject tu DespawnByDistance va thay doi hanh vi cua no
    // DespawnByDistance: se Destroy
    // BulletDespawn: se nem cac vien dan do vao poolObject
    public override void DespawnObject()
    {
        JunkSpawner.Instance.Despawn(transform.parent);
    }

    //Thay doi gia tri ke thua tu bang cach truy cap vao ham ResetValue tu ClassBehaviour
    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 25f;
    }
}
