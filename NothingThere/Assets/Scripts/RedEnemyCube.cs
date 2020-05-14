using UnityEngine;

public class RedEnemyCube : CubeController
{
    protected new void OnTriggerEnter(Collider other)
    {
        PlayerLogic plrHP = other.GetComponent<PlayerLogic>();
        /*if (base.rend.material.color != base.newColor)
        {
            base.OnTriggerEnter(other);

            plrHP.AddHP(-1);
        }*/

        //if (!base.animator.GetBool("isUsed"))
        if (base.rend.material.color != base.newColor)
        {
            if (base.newColor.Equals(new Color32(0, 0, 0, 0))) base.newColor = Color.white;
            base.OnTriggerEnter(other);

            plrHP.AddHP(-1);
        }
    }
}
