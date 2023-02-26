using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition; //Vector3 se gom 3 toa do laf: x, y, z
    [SerializeField] protected float speed = 0.01f;

    void FixedUpdate(){
        this.GetTargetPosition();
        this.LootAtTarget();
        this.Moving();
    }

    protected virtual void GetTargetPosition()
    {
        //gan wordPosition = vi tri con tro chuot
        //this.wordPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        // vi vector3 co toa do x,y,z. nhung game 2d nen ta se set default truc z = 0
        this.targetPosition.z = 0;
    }

    protected virtual void LootAtTarget() //ham nay de khi di chuyen, dau cua nhan vat se huong toi con tro chuot
    {
        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z );
    }

    protected virtual void Moving()
    {
        //De update lai vi tri cua toa do, ta sd ham Lerp cua Vector3
        //Ham Lefp nhan vao 3 gia tri: Vi tri hien tai, vi tri muon di chuyen toi, toc do
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, this.speed); // .parent co nghia la lay thuoc tinh transform tu gameObject Ship (folder cha)
        transform.parent.position = newPos; //gan lai vi tri moi
    }
}
