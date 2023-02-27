using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : PlayerAbstract
{

    //ham nay se add item nhat dc vao Inventory va sau do se despawn item do
    public virtual void ItemPickup(ItemPickupable itemPickupable)
    {
        Debug.Log("ItemPickup");

        ItemCode itemCode = itemPickupable.GetItemCode();
        if (this.playerCtrl.CurrentShip.Inventory.AddItem(itemCode, 1))
        {
            itemPickupable.Picked();
        }
    }
}
