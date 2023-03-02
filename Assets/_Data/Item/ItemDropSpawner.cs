using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (ItemDropSpawner.instance != null) Debug.LogError("Only 1 ItemDropSpawner exist");
        ItemDropSpawner.instance = this;
    }

    //Lay danh sach vat pham drop
    public virtual void Drop(List<DropRate> dropList, Vector3 pos, Quaternion rot)
    {
        if (dropList.Count < 1) return;
        ItemCode itemCode = dropList[0].itemSO.itemCode; //lay itemCode cua item dau tien
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }

    //Ham drop nay la drop ra item sau khi dc nang cap
    public virtual Transform Drop(ItemInventory itemInventory, Vector3 pos, Quaternion rot)
    {
        ItemCode itemCode = itemInventory.itemProfile.itemCode;

        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        if (itemDrop == null) return null;
        itemDrop.gameObject.SetActive(true);

        //tao lien ket
        //de luc roi do ra, thong so cua item dc nang cap van dc giu nguyen
        ItemCtrl itemCtrl = itemDrop.GetComponent<ItemCtrl>();
        itemCtrl.SetItemInventory(itemInventory);

        return itemDrop;
    }
}
