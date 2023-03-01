using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel : LevelByDistance
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate(); //de dam rang no luon goi vao ham FixedUpdate ma no ke thua
        this.MapSetTarget();
    }

    //private void FixedUpdate()
    //{
       // this.MapSetTarget();
    //}

    protected virtual void MapSetTarget()
    {
        if (this.target != null) return;
        ShipCtrl currentShip = PlayerCtrl.Instance.CurrentShip; //Lay vi tri cua ship
        this.SetTarget(currentShip.transform); //truyen con tau vao ham SetTarget
    }
}
