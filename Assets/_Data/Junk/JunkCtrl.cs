using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class JunkCtrl dong vai tro nhu 1 class trung gian de lien ket voi cac class khac
public class JunkCtrl : ClassBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get => junkDespawn; }

    [SerializeField] protected JunkSO junkSO;
    public JunkSO JunkSO { get => junkSO; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
        this.LoadJunkSO();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
    }

    protected virtual void LoadJunkDespawn()
    {
        if (this.junkDespawn != null) return;
        this.junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
        Debug.Log(transform.name + ": LoadJunkDespawn", gameObject);
    }

    protected virtual void LoadJunkSO()
    {
        if(this.junkSO != null) return;
        // tao duong dan den JunkSO
        // Junk: la ten folder trong folder Resources
        // transform.name: la ten item prefab (vd: o day la cac thien thach Meteorite_1, Meteorite_2,...)
        string resPath = "Junk/" + transform.name; 
        this.junkSO = Resources.Load<JunkSO>(resPath); //dung ham Resources.Load de tao lien ket
    }
}
