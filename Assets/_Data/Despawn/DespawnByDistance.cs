using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class nay dung de xoa vien dan, neu nhu vien dan do bay cach xa camera 70m thi xoa
public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 70f; //70m
    [SerializeField] protected float distance = 0f; //dung de kiem tra khoang cach tu vi tri hien tai cua vien dan den camera
    [SerializeField] protected Transform mainCam; //camera

    protected override void LoadComponents()
    {
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCam != null) return;
        this.mainCam = Transform.FindObjectOfType<Camera>().transform;
        Debug.Log(transform.parent.name + ": LoadCamera", gameObject);
    }

    //protected virtual void Despawning()
    //{
        //if (!this.CanDespawn()) return;
        //this.DespawnObject();
   // }

    //public virtual void DespawnObject()
    //{
        //Destroy(transform.parent.gameObject);
    //}

    protected override bool CanDespawn() //la ham ke thua, cua class Despawn nen se co kieu la override
    {
        this.distance = Vector3.Distance(transform.position, mainCam.position); // tinh khoang cach tu vi tri hien tai cua vien dan den camera
        if (this.distance > this.disLimit) return true;
        return false;
    }
}
