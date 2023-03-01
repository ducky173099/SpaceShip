using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.2f; // bien nay de delay toc do ban, moi giay ban 1 phat
    [SerializeField] protected float shootTimer = 0f; // bo dem thoi gian
    //[SerializeField] protected Transform bulletPrefab;

    void Update()
    {
        this.IsShooting();
    }

    private void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        //delay toc do dan ban ( time duoc tinh sau khi click chuot ban)
        this.shootTimer += Time.fixedDeltaTime; // cong don time tu 0 den 1
        if (!this.isShooting) return;
        if (this.shootTimer < this.shootDelay) return; // neu timer < shootingDelay thi k lam gi ca
        this.shootTimer = 0; //Neu >= thi set = 0 va dung lai

        //vi tri con tau hien tai
        Vector3 spawnPos = transform.position;
        // goc ban
        Quaternion rotation = transform.parent.rotation;

        //Transform newBullet = Instantiate(this.bulletPrefab, spawnPos, rotation);
        //cachs su ke thua
        //Transform newBullet = Spawner.instance.Spawn(spawnPos, rotation);
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true); //vi ban dau prefab bi disable tu file spawner nen ta se hai active lai nhu nay
        
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>(); //bien shooter tu BulletCtrl lay tu day
        bulletCtrl.SetShotter(transform.parent);
        //Debug.Log("Shooting");
    }

    protected virtual bool IsShooting() // cap nhat lai bien isShooting, neu click chuot trai thi ban va nguoc lai
    {
        this.isShooting =  InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
}
