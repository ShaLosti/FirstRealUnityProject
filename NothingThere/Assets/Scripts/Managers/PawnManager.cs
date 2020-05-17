using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnManager : MonoBehaviour
{
    public static void TeleportPawn(Transform point, GameObject pawn = null)
    {
        if (pawn == null)
        {
            pawn = GameManager.plrGameObject;
            pawn.transform.position = new Vector3(point.position.x, point.position.y, point.position.z);
            pawn.transform.rotation = Quaternion.identity;
        }
        else
        {
            pawn.transform.position = new Vector3(point.position.x, point.position.y, point.position.z);
            pawn.transform.rotation = Quaternion.identity;
        }
    }

    public static void TeleportPawn(float x, float y, float z, GameObject pawn = null)
    {
        if (pawn == null)
        {
            pawn = GameManager.plrGameObject;
            pawn.transform.position = new Vector3(x, y, z);
            pawn.transform.rotation = Quaternion.identity;
        }
        else
        {
            pawn.transform.position = new Vector3(x, y, z);
            pawn.transform.rotation = Quaternion.identity;
        }
    }
}
