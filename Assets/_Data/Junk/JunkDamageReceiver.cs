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

    protected override void OnDead() //ham nay dc goi khi object do bi huy
    {
        this.OnDeadFX(); //cai them hieu ung khi dead
        this.OnDeadDrop();//roi item
        this.junkCtrl.JunkDespawn.DespawnObject();
    }

    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position; //lay vi tri hien tai cua thien thach
        Quaternion dropRot = transform.rotation;//lay goc quay hien tai cua thien thach
        //Truyen vao danh sach cac Item drop, vi tri xuat hien, goc quay
        ItemDropSpawner.Instance.Drop(this.junkCtrl.ShootableObject.dropList, dropPos, dropRot);
    }

    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();// lay ten hieu ung
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smoke1;
    }

    public override void Reborn()
    {
        //ta gan lai gia tri cua hpMax truoc khi chay base.Reborn()
        // boi vi truoc khi no gan hp = hpMax ben ham tu class cha
        // ta gan hpMax = hpMax tu class JunkSO
        this.hpMax = this.junkCtrl.ShootableObject.hpMax;
        base.Reborn();
    }
}
