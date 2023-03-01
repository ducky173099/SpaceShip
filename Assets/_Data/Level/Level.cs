using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Class quan ly level cua cac doi tuong trong du an
public class Level : ClassBehaviour
{
    [Header("Level")]

    [SerializeField] protected int levelCurrent = 0;
    [SerializeField] protected int levelMax = 99;

    public int LevelCurrent => levelCurrent;
    public int LevelMax => levelMax;

    public virtual void LevelUp() //ham len 1 level
    {
        this.levelCurrent += 1;
        this.LimitLevel();
    }

    public virtual void LevelSet(int newLevel) //ham len 1 luc nhieu level
    {
        this.levelCurrent = newLevel;
        this.LimitLevel();
    }

    protected virtual void LimitLevel() //gioi han level
    {
        if(this.levelCurrent > this.levelMax) this.levelCurrent = this.levelMax;
        if(this.levelCurrent < 1) this.levelCurrent = 1;
    }
}
