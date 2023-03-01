using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : ParentFly
{

    [SerializeField] protected float minCamPos = -9f;
    [SerializeField] protected float maxCamPos = 9f;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 0.5f;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetFlyDirection();
    }

    //Ham nay tinh toan lai duong bay cua thien thach
    protected virtual void GetFlyDirection()
    {
        //Vector3 camPos = GameCtrl.Instance.MainCamera.transform.position; //Lay vi tri camera
        Vector3 camPos = this.GetCamPos(); //Lay vi tri camera
        Vector3 objPos = transform.parent.position; //Lay vi tri hien tai cua obj

        camPos.x += Random.Range(this.minCamPos, this.maxCamPos); //random truc X de thay doi tam cua camera
        camPos.z += Random.Range(this.minCamPos, this.maxCamPos);

        Vector3 diff = camPos - objPos; // Huong di chuyen cua thien thach
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);

        Debug.DrawLine(objPos, objPos + diff * 7, Color.red, Mathf.Infinity); // khi log ra tren man hinh se ve ra huong di chuyen cua vat the
    }

    protected virtual Vector3 GetCamPos()
    {
        if (GameCtrl.Instance == null) return Vector3.zero;
        Vector3 camPos = GameCtrl.Instance.MainCamera.transform.position; //Lay vi tri camera
        return camPos;

    }
}
