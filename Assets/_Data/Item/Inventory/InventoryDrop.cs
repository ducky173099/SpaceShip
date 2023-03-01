using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDrop : InventoryAbstract
{
    //[Header("Item inventory drop")]

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(Test), 5);
    }

    protected virtual void Test()
    {
        Vector3 dropPos = transform.position;
        dropPos.x += 1;
        this.DropItemIndex(0, dropPos, transform.rotation);
    }

    //Ham nay drop nhung item sau khi nang cap dc roi ra
    protected virtual void DropItemIndex(int itemIndex, Vector3 dropPos, Quaternion dropRot)
    {
        ItemInventory itemInventory = this.inventory.Items[itemIndex];
        //Debug.Log(itemInventory.itemProfile.itemCode);
        //Debug.Log(itemInventory.upgradeLevel);
        ItemDropSpawner.Instance.Drop(itemInventory, dropPos, dropRot);
        //sau khi drop ra item ra khoi kho do, ta remove no di
        this.inventory.Items.Remove(itemInventory);
    }
}
