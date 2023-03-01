using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : ClassBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;

    //Bien de luwu thong tin item dc roi ra khi nang cap
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDespawn();
        this.LoadItemInventory(); //Load thong tin inventory cho moi itemdrop
    }

    //khi despawn item drop, t se reset lai no
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetItem();
    }

    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
    }

    protected virtual void LoadItemInventory()
    {
        if(this.itemInventory.itemProfile != null) return;
        //Lay itemCOde tu object name
        ItemCode itemCode = ItemCodeParser.FromString(transform.name);
        //tim itemProfile thong qua itemCode
        ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);

        //gan itemProfile va itemCount vao
        this.itemInventory.itemProfile = itemProfile;
        //this.itemInventory.itemCount = 1;
        this.ResetItem();
    }

    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory.Clone();
        /*
        this.itemInventory = new ItemInventory();
        this.itemInventory.itemProfile = itemInventory.itemProfile;
        this.itemInventory.itemCount = itemInventory.itemCount;
        this.itemInventory.upgradeLevel = itemInventory.upgradeLevel;
        */
    }

    protected virtual void ResetItem()
    {
        this.itemInventory.itemCount = 1;
        this.itemInventory.upgradeLevel = 0;
    }
}
