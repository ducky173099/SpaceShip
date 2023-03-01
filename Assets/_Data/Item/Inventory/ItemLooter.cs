using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Khai bao thu vien nhu the nay co tac dung add thang 2 component sau vao Inspector
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]


//Class nay se lien ket voi class Inventory
//Class Inventory se biet den thang Ship
// Inventory dung giua nhu la trung gian
public class ItemLooter : InventoryAbstract
{
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
        this.LoadRigidbody();
    }

    protected virtual void LoadTrigger()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.3f;
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody>();
        this._rigidbody.useGravity = false;
        this._rigidbody.isKinematic = true;
    }


    //Ham nay se xu ly su kien va cham voi cac Item
    protected virtual void OnTriggerEnter(Collider collider)
    {
        ItemPickupable itemPickupable = collider.GetComponent<ItemPickupable>(); //lay component item
         //kt neu co item pickup thi xu ly, con k thi bo qua
        if (itemPickupable == null) return;
        //Debug.Log(collider.name);
        //Debug.Log(collider.transform.parent.name);
        //Debug.Log("====> Co the pick do");

        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;
        if(this.inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}
