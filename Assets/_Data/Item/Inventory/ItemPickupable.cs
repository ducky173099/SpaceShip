using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : ItemAbstract
{
    [Header("item pickupable")]

    [SerializeField] protected SphereCollider _collider;

    //giai thuat chuyen string thanh Enum
    public static ItemCode String2ItemCode(string itemName)
    {
        try
        {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        }
    }

    //ham click chuot de nhat do
    public virtual void OnMouseDown()
    {
        //Debug.Log(transform.parent.name);
        // this: dai dien cho class ItemPickupable
        PlayerCtrl.Instance.PlayerPickup.ItemPickup(this);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
    }

    protected virtual void LoadTrigger()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.2f;
    }

    //Lay ten cua itemCode
    public virtual ItemCode GetItemCode()
    {
        return ItemPickupable.String2ItemCode(transform.parent.name);
    }

    //sau khi pick item thi no se bi despawn di
    public virtual void Picked()
    {
        this.itemCtrl.ItemDespawn.DespawnObject();
    }

  
}