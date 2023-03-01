using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : PlayerAbstract
{

    //ham nay se add item nhat dc vao Inventory va sau do se despawn item do
    public virtual void ItemPickup(ItemPickupable itemPickupable)
    {
        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;
        //Debug.Log(itemPickupable.ItemCtrl.ItemInventory.itemProfile.upgradeLevels + "======> itemPickupable: ");

        if (this.playerCtrl.CurrentShip.Inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}
