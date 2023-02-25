using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    // khi ma vien da dc despawn, thi no se quay lai poolobject
    // class nay thua ke lai ham DespawnObject tu DespawnByDistance va thay doi hanh vi cua no
    // DespawnByDistance: se Destroy
    // BulletDespawn: se nem cac vien dan do vao poolObject
    public override void DespawnObject() 
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
