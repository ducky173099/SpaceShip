using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Spawner : MonoBehaviour
public abstract class Spawner : ClassBehaviour
{
    [Header("Spawner")]

    [SerializeField] protected Transform holder;

    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount => spawnedCount;

    [SerializeField] protected List<Transform> prefabs; //tao ra 1 bien chua list cac prefab
    [SerializeField] protected List<Transform> poolObjs;


    // vi class Spawner dc ke thua tu class ClassBehaviour (trong class do da khai bao ham virtual Awake() r) 
    //nen ta se khai bao ham Awake trong class Spawner laf override
  
    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;//Kiem tra neu ban dau prefab da dc reset add vao r thi thoi, con neu k thif se chay am Reset

        Transform prefabObj = transform.Find("Prefabs"); //tao lien ket toi folder chua cacs prefabs
        foreach(Transform prefab in prefabObj) //no se lap qua cac phan tu con ben trong object Prefabs
        {
            this.prefabs.Add(prefab); //add prefab vao list prefabs khai bao ben tren
        }

        //prefab mac dinhj k dc chayj khi start game, nen ban dau ta se disable di
        this.HidePrefabs();

        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach(Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }


    //1 method Spawn co 2 cach goi, Spawn tren se truyen vao string, con Spawn duoi se truyen vao Tranform
    //Ham spawn ra object
    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        //Transform prefab = this.prefabs[0];
        Transform prefab = this.GetPrefabByName(prefabName);
        if(prefab == null)
        {
            Debug.LogWarning("Prefab not found: " + prefabName);
            return null;
        }

        return this.Spawn(prefab, spawnPos, rotation);
    }

    //Ham nay de khi random, no se tra ve 1 prefab luon chu k lay ra name cua prefab nua
    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {

        //lay prefab ma ta can spawn ra
        //Transform newPrefab = Instantiate(prefab, spawnPos, rotation);
        Transform newPrefab = this.GetObjectFromPool(prefab); //Kiem tra xem prefab nay da co trong GetObjectFromPool hay chua
        newPrefab.SetPositionAndRotation(spawnPos, rotation); // set lai vi tri vien dan

        newPrefab.parent = this.holder;
        this.spawnedCount++; //moi lan spawn, ta tang bien nay len den gioi han thi k spawn nua

        return newPrefab;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach(Transform poolObj in this.poolObjs)
        {
            if (poolObj == null) continue;
            //Kiem tra xem cos trung ten hay k
            // neu trung thi se spawn cai object do ra de su dung
            // va remove object trong pool di
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj); 
                return poolObj;
            }
        }

        //Neu duyet qua het poolObj ben tren ma k co object ma chung ta can
        // thi ta se tao moi
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name; // set ten cho giong
        return newPrefab;
    }


    // khi Despawn nay dc goi, no se add object do vao Pool
    // Sau khi add vao pool, no se disable obj do di
    public virtual void Despawn(Transform obj)
    {
        //khi spawn 1 vien dan ra, thi vien dan do se nam trong holder
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnedCount--; //giam bien nay moi lan despawn
    }

    //Ham lay ten prefabName
    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach(Transform prefab in this.prefabs)
        {
            if(prefab.name == prefabName) return prefab;
        }

        return null;
    }


    //Random lua chon thien thach
    public virtual Transform RandomPrefab()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }
}
