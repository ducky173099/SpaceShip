using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ClassBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items; // danh sach item

    public List<ItemInventory> Items => items;

    protected override void Start()
    {
        base.Start();
        this.AddItem(ItemCode.CopperSword, 1);
        this.AddItem(ItemCode.GoldOre, 10);
        this.AddItem(ItemCode.IronOre, 10);

    }

    //add item tu inventory khi pick do bi roi ra khi dc nang cap
    //add item ma giu nguyen level chi tac dung cho nhung item la equiment
    public virtual bool AddItem(ItemInventory itemInventory)
    {
        int addCount = itemInventory.itemCount;
        ItemProfileSO itemProfile = itemInventory.itemProfile;
        ItemCode itemCode = itemProfile.itemCode;
        ItemType itemType = itemProfile.itemType;

        if (itemType == ItemType.Equiment) return this.AddEquiment(itemInventory);
        return this.AddItem(itemCode, addCount);
    }

    public virtual bool AddEquiment(ItemInventory itemPicked)
    {
        if (this.IsInventoryFull()) return false;

        ItemInventory item = itemPicked.Clone();
        /*
        ItemInventory item = new ItemInventory();
        item.itemProfile = itemPicked.itemProfile;
        item.itemCount = itemPicked.itemCount;
        item.upgradeLevel = itemPicked.upgradeLevel;
        */

        this.items.Add(item);
        return true;
    }

    // Ham nay de nhat item la resource
    public virtual bool AddItem(ItemCode itemCode, int addCount) //No se nhan vao itemcode va so luong item
    {
        ItemProfileSO itemProfile = this.GetItemProfile(itemCode);

        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        int addMore;
        ItemInventory itemExist;

        for (int i = 0; i < this.maxSlot; i++)
        {
            itemExist = this.GetItemNotFullStack(itemCode); //kiem tra xem trong inventory hien tai da cos san slot nao chua
            if(itemExist == null) //newu nhu k tim thay itemCOde hoac null
            {
                if (this.IsInventoryFull()) return false;

                //tao ra 1 item empty va add vao
                itemExist = this.CreateEmptyItem(itemProfile);
                this.items.Add(itemExist);
            }

            //neu trong truong hop tim thay itemCode
            newCount = itemExist.itemCount + addRemain;

            //tinh toan xem slot hien tai con phai + bao nhieu thi de full stack do
            itemMaxStack = this.GetMaxStack(itemExist);
            if(newCount > itemMaxStack)
            {
                addMore = itemMaxStack - itemExist.itemCount;
                newCount = itemExist.itemCount + addMore;
                addRemain -= addMore;
            }
            else
            {
                addRemain -= newCount;
            }

            itemExist.itemCount = newCount;
            if (addRemain < 1) break;
        }

        return true;
    }

    protected virtual bool IsInventoryFull()
    {
        if (this.items.Count >= this.maxSlot) return true;

        return false;
    }

    protected virtual int GetMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;
        return itemInventory.maxStack;
    }

    protected virtual ItemProfileSO GetItemProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if(profile.itemCode != itemCode) continue;
            return profile;
        }

        return null;
    }

    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        foreach(ItemInventory itemInventory in this.items) //duyet qua tung item trong game
        {
            //check xem item nao == voi itemCode
            if (itemCode != itemInventory.itemProfile.itemCode) continue; //neu k bang thi se bo qua inventory do
            //neu == thi se kiem tra xem da full hay chua
            if (this.IsFullStack(itemInventory)) continue;  //neu full thi se bo qua
            return itemInventory; //neu dung item k full va == itemCode thif se return
        }
        return null;
    }

    protected virtual bool IsFullStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return true;

        int maxStack = this.GetMaxStack(itemInventory);
        return itemInventory.itemCount >= maxStack;
    }

    protected virtual ItemInventory CreateEmptyItem(ItemProfileSO itemProfile)
    {
        ItemInventory itemInventory = new ItemInventory
        {
            itemProfile = itemProfile,
            maxStack = itemProfile.defaultMaxStack
        };

        return itemInventory;
    }

    public virtual bool ItemCheck(ItemCode itemCode, int numberCheck)
    {
        int totalCount = this.ItemTotalCount(itemCode);
        return totalCount >= numberCheck;
    }

    public virtual int ItemTotalCount(ItemCode itemCode)//check count trong item
    {
        int totalCount = 0;
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.itemProfile.itemCode != itemCode) continue;
            totalCount += itemInventory.itemCount;
        }

        return totalCount;
    }

    public virtual void DeductItem(ItemCode itemCode, int deductCount)
    {
        ItemInventory itemInventory;
        int deduct;
        for (int i = this.items.Count - 1; i >= 0; i--)
        {
            if (deductCount <= 0) break;

            itemInventory = this.items[i];
            if (itemInventory.itemProfile.itemCode != itemCode) continue;

            if (deductCount > itemInventory.itemCount)
            {
                deduct = itemInventory.itemCount;
                deductCount -= itemInventory.itemCount;
            }
            else
            {
                deduct = deductCount;
                deductCount = 0;
            }

            itemInventory.itemCount -= deduct;
        }


        this.ClearEmptySlot();
    }


    //Ham nay dung de remove cac slot item co count = 0 trong inventory
    protected virtual void ClearEmptySlot()
    {
        //for() co the thay doi phan tu ben trong tap hop hoac co the truy cap cac item truoc hoac sau vong duyet hien tai
        //foreach chi dung de duyet mang
        ItemInventory itemInventory;
        for (int i = 0; i < this.items.Count; i++)
        {
            itemInventory = this.items[i];
            if (itemInventory.itemCount == 0) this.items.RemoveAt(i);
        }
    }


    /*
     * 
         public virtual bool AddItem(ItemCode itemCode, int addCount) //No se nhan vao itemcode va so luong item
    {
        //ItemInventory itemInventory = this.GetItemByCode(itemCode); //Tim trong ds item da ton tai itemCode nay chua

        //cong don item do neu co r
        //int newCount = itemInventory.itemCount + addCount;
        //if (newCount > itemInventory.maxStack) return false; //dk la k dc vuot qua maxStack

        //itemInventory.itemCount = newCount;
        //return true;
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
        //load all resource trong Item
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
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
    */
}
