using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpgrade : InventoryAbstract
{
    [Header("Item upgrade")]

    [SerializeField] protected int maxLevel = 9;

    protected override void Start()
    {
        base.Start();

        Invoke(nameof(this.Test), 2);
    }

    protected virtual void Test()
    {
        this.UpgradeItem(0);
    }


    public virtual bool UpgradeItem(int itemIndex) //truyen vao thu tu item muon nang cap
    {
        //kiem tra xem itemIndex co nam trong idex ma item co hay k
        if (itemIndex >= this.inventory.Items.Count) return false;

        ItemInventory itemInventory = this.inventory.Items[itemIndex]; //lay item Inventory
        if (itemInventory.itemCount < 1) return false; //kiem tra xem itemCount co slot do hay k

        //lay upgradeLevel
        List<ItemRecipe> upgradeLevels = itemInventory.itemProfile.upgradeLevels;
        if (!this.ItemUpgradeable(upgradeLevels)) return false; //Kiem tra xem voi upgradeLevels ben tren, ta co the nang cap dc hay k
        if (!this.HaveEnoughIngredients(upgradeLevels, itemInventory.upgradeLevel)) return false; //Kiem tra xem item co du do hay k

        this.DeductIngredients(upgradeLevels, itemInventory.upgradeLevel); //tru di so luong cac item dung de upgrade level
        itemInventory.upgradeLevel++;

        return true;
    }

    protected virtual bool ItemUpgradeable(List<ItemRecipe> upgradeLevels)
    {
        if (upgradeLevels.Count == 0) return false;
        return true;
    }

    protected virtual bool HaveEnoughIngredients(List<ItemRecipe> upgradeLevels, int currentLevel)
    {
        ItemCode itemCode;
        int itemCount;


        //kiem tra xem level hien tai tai co nang cap dc len level tiep theo hay k
        if (currentLevel > upgradeLevels.Count)
        {
            Debug.LogError("Item cant upgrade anymore, current: " + currentLevel);
            return false;
        }

        ItemRecipe currentRecipeLevel = upgradeLevels[currentLevel]; //lay recipe cua level hien tai
        //sau do se lay ra dc ingredients cua item
        foreach (ItemRecipeIngredient ingredient in currentRecipeLevel.ingredients)
        {
            itemCode = ingredient.itemProfile.itemCode;
            itemCount = ingredient.itemCount;
            //kiem tra thong tin item
            if (!this.inventory.ItemCheck(itemCode, itemCount)) return false;
        }
        return true;
    }

    protected virtual void DeductIngredients(List<ItemRecipe> upgradeLevels, int currentLevel)
    {
        ItemCode itemCode;
        int itemCount;

        ItemRecipe currentRecipeLevel = upgradeLevels[currentLevel];
        foreach (ItemRecipeIngredient ingredient in currentRecipeLevel.ingredients)
        {
            itemCode = ingredient.itemProfile.itemCode;
            itemCount = ingredient.itemCount;

            this.inventory.DeductItem(itemCode, itemCount);
        }
    }
}
