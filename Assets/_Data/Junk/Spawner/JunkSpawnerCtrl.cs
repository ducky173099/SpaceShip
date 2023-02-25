using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerCtrl : ClassBehaviour
{
    // Ham nay de lien ket JunkRandom va JunkSpawner
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner { get => junkSpawner; }

    [SerializeField] protected JunkSpawnPoints junkSpawnPoints; //Bien de tao lien ket
    public JunkSpawnPoints JunkSpawnPoints { get => junkSpawnPoints; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.junkSpawnPoints != null) return;
        // tu dong Load component SpawnPoints lien ket
        // Do lien ket den 1 gameobj cung cap, nen ta sd Transform de tim den
        this.junkSpawnPoints = Transform.FindObjectOfType<JunkSpawnPoints>();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>(); // tu dong Load component JunkSpawner
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }
}
