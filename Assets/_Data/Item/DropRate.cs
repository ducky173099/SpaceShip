using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] // tac dung co no la de co the hien thi cac thuoc tinh ben ngoai Inspector
public class DropRate 
{
    public ItemProfileSO itemSO;
    public int dropRate;
    public int minDrop;
    public int maxDrop;
}
