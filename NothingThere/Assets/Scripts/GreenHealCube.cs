using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenHealCube : CubeController
{
    protected new void OnCollisionEnter(Collision collision)
    {
        /*if (base.rend.material.color != base.newColor && plrHP.CurrentHealth < plrHP.MaxHealth)
        {
            base.OnTriggerEnter(other);

            plrHP.AddHP(1);
        }*/
        //if (!base.animator.GetBool("isUsed") && plrHP.CurrentHealth < plrHP.MaxHealth)
        ITakeDamage plrHP = collision.gameObject.GetComponent<ITakeDamage>();
        if (base.rend.material.color != base.newColor && plrHP.CurrentHP < plrHP.MaxHP)
        {
            if (base.newColor.Equals(new Color32(0, 0, 0, 0))) base.newColor = Color.white;
            base.OnCollisionEnter(collision);
            plrHP.AddHP(1);
        }
    }
}
