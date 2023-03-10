using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDamageReceiver : DamageReceiver
{
    [Header("Den tu Junk")]

    [SerializeField] protected JunkCtrl junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
    }

    protected override void OnDead()
    {
        this.junkCtrl.JunkDespawn.DespawnObject();
    }

    public override void Reborn()
    {
        //ta gan lai gia tri cua hpMax truoc khi chay base.Reborn()
        // boi vi truoc khi no gan hp = hpMax ben ham tu class cha
        // ta gan hpMax = hpMax tu class JunkSO
        this.hpMax = this.junkCtrl.JunkSO.hpMax;
        base.Reborn();
    }
}
