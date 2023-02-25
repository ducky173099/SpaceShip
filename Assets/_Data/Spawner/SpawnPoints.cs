using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//abstract khai bao se k cho phep sd như 1 component truc tiep ma phai ke thua sang class khac
public abstract class SpawnPoints : ClassBehaviour
{
    [SerializeField] protected List<Transform> points;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }

    protected virtual void LoadPoints() //Ham nay de add cac vi tri random cho thien thach
    {
        if (this.points.Count > 0) return;
        foreach(Transform point in transform)
        {
            this.points.Add(point);
        }
    }

    public virtual Transform GetRandom()
    {
        int rand = Random.Range(0, this.points.Count);
        return this.points[rand];
    }
}
