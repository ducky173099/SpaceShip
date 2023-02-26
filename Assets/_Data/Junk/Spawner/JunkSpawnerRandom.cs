using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : ClassBehaviour
{
    [Header("Den tu Junk Random")]

    // Ham JunkSpawnerRandom duoc lien ket vo JunkSpawner thong qua hamf JunkCtrl
    [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 9f;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkSpawnerCtrl != null) return;
        this.junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>(); // tu dong Load component JunkCtrl
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;

        // cu sau 1s thi no se goi lai ham JunkSpawning 1 lan
        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;

        Transform ranPoint = this.junkSpawnerCtrl.JunkSpawnPoints.GetRandom();

        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = this.junkSpawnerCtrl.JunkSpawner.RandomPrefab(); //goi den ham random hinh anh thien thach
        Transform obj = this.junkSpawnerCtrl.JunkSpawner.Spawn(prefab, pos, rot); //sinh ra thien thach
        obj.gameObject.SetActive(true); //set active true de hien thi hinh anh
        
        //Invoke(nameof(this.JunkSpawning), 1f); // cu sau 1s thi no se goi lai ham JunkSpawning 1 lan
    }

    //ham nay kiem soat xem da spawn ra du cai thien thach da gioi han chua ( o day la 9), neu du r thi no doi despawn di r moi sinh ra tiep
    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.junkSpawnerCtrl.JunkSpawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }
}
