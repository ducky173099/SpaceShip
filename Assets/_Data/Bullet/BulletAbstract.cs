using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//BulletAbstract se tao san lien ket den BulletCtrl de cac class khac ke thua tu no
public class BulletAbstract : ClassBehaviour
{
    [Header("Den tu Bullet Abstract")]
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl { get => bulletCtrl;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": ===LoadBulletCtrl", gameObject);
    }
}
