using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
    }

    //Thay doi gia tri ke thua tu bang cach truy cap vao ham ResetValue tu ClassBehaviour
    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 25f;
    }
}
