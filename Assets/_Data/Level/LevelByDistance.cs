using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Ham len level bang khoang cach
public class LevelByDistance : Level
{
    [Header("Level by distance")]

    [SerializeField] protected Transform target; //target: la muc tieu de do khoang cach 
    [SerializeField] protected float distance = 0;
    [SerializeField] protected float distancePerLevel = 10f; // moi 1 cap tuong ung voi gia tri distancePerLevel dc khai bap


    protected virtual void FixedUpdate()
    {
        this.Levelling();
    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

    protected virtual void Levelling()
    {
        if (this.target == null) return; //kiem tra xem co target hay chua
        //neu co target, thi ta tinh khoang cach nhu sau
        this.distance = Vector3.Distance(transform.position, target.position);
        int newLevel = this.GetLevelByDis();
        this.LevelSet(newLevel);
    }

    protected virtual int GetLevelByDis()
    {
        return Mathf.FloorToInt(this.distance / this.distancePerLevel) + 1;
    }
}
