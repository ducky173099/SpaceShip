using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : ClassBehaviour
{
    private static DropManager instance; // cach de truy cap InputManager toan cuc
    public static DropManager Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (DropManager.instance != null) Debug.LogError("Only 1 DropManager allow to exist");
        DropManager.instance = this;// cach de truy cap InputManager toan cuc
    }

    public virtual void Drop(List<DropRate> dropList)
    {
        Debug.Log(dropList[0].itemSO.itemName);
    }
}
