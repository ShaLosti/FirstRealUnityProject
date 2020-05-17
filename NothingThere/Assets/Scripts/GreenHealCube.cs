using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenHealCube : CubeController
{
    protected new void OnTriggerEnter(Collider other)
    {
        ITakeDamage plrHP = other.GetComponent<ITakeDamage>();
        /*if (base.rend.material.color != base.newColor && plrHP.CurrentHealth < plrHP.MaxHealth)
        {
            base.OnTriggerEnter(other);

            plrHP.AddHP(1);
        }*/
        //if (!base.animator.GetBool("isUsed") && plrHP.CurrentHealth < plrHP.MaxHealth)
        if(base.rend.material.color != base.newColor && plrHP.CurrentHP < plrHP.MaxHP)
        {
            if (base.newColor.Equals(new Color32(0, 0, 0, 0))) base.newColor = Color.white;
            base.OnTriggerEnter(other);

            plrHP.AddHP(1);
        }
    }
}
