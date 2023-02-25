using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DamageSender co 2 nhiem vu gui damage sang DamageReceiver vaf neu tru het hp thi destroy thien thach
public class DamageSender : ClassBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform obj) // Ham nay se gui damage cho 1 object nao do, o day la no se gui den DamageReceiver
    {
        //Kiem tra xem obj do, ben trong no co component DamageReceiver hay k
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver); //neu no obj do thino co the nhan damage dc
    }

    //ham nay se nhan damage tu damageSender truyen qua hamf Deduct cuar DamageReceiver
    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
        //this.DestroyObject(); //sau do se huy object
    }

    //protected virtual void DestroyObject()
    //{
        //Destroy(transform.parent.gameObject);
    //}
}
