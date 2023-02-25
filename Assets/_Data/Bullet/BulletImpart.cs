using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dua 2 dong duoi vao thi o ben Unity ta se k the xoa no di
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class BulletImpart : BulletAbstract
{
    [Header("Den tu Bullet Impart")]

    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        //2 Ham duoi de tao lien ket, tu dong hoa dieu chinh 2 component sao cho dung cac thong so ma ta can sd
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.isKinematic= true; //set bang true de trong luc k khien no roi
    }

    //Ham nay se dc goi khi Collider cua Bullet va cham voi Collider cua Meteorite
    protected virtual void OnTriggerEnter(Collider other)
    {
        this.bulletCtrl.DamageSender.Send(other.transform);
    }
}
