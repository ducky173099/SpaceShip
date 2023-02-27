using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ClassBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items; // danh sach item

    // Ham nay de nhat item
    public virtual bool AddItem(ItemCode itemCode, int addCount) //No se nhan vao itemcode va so luong item
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode); //Tim trong ds item da ton tai itemCode nay chua

        //cong don item do neu co r
        int newCount = itemInventory.itemCount + addCount;
        if (newCount > itemInventory.maxStack) return false; //dk la k dc vuot qua maxStack

        itemInventory.itemCount = newCount;
        return true;
    }

    protected virtual bool DeductItem(ItemCode itemCode, int addCount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        int newCount = itemInventory.itemCount - addCount;
        if(newCount < 0) return false;

        itemInventory.itemCount = newCount;
        return true;
    }

    //Ham nay kiem tra xem muon tru item k
    public virtual bool TryDeductItem(ItemCode itemCode, int addCount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        int newCount = itemInventory.itemCount - addCount;
        if(newCount < 0) return false;
        return true;
    }

    public virtual ItemInventory GetItemByCode(ItemCode itemCode)
    {
        ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
        // trong truong hop k ton tai item Inventory nao, ta add 1 rmpty profile
        if (itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode); 
        return itemInventory;
    }
    protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
    {
        //load all resource trong ItemProfiles
        var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            ItemInventory itemInventory = new ItemInventory
            {
                itemProfile = profile,
                maxStack = profile.defaultMaxStack
            };
            this.items.Add(itemInventory);
            return itemInventory;
        }

        return null;
    }
}
