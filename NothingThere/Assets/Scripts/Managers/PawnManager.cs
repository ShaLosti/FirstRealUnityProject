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
            pawn.GetComponent<CharacterController>().enabled = false;
            pawn.transform.position = new Vector3(point.position.x, point.position.y, point.position.z);
            pawn.transform.rotation = Quaternion.identity;
            pawn.GetComponent<CharacterController>().enabled = true;
        }
        else
        {
            if (pawn.GetComponent<CharacterController>() != null)
            {
                pawn.GetComponent<CharacterController>().enabled = false;
                pawn.transform.position = new Vector3(point.position.x, point.position.y, point.position.z);
                pawn.transform.rotation = Quaternion.identity;
                pawn.GetComponent<CharacterController>().enabled = true;
            }
            else
            {
                pawn.transform.position = new Vector3(point.position.x, point.position.y, point.position.z);
                pawn.transform.rotation = Quaternion.identity;
            }
        }
    }

    public static void TeleportPawn(float x, float y, float z, GameObject pawn = null)
    {
        if (pawn == null)
        {
            pawn = GameManager.plrGameObject;
            pawn.GetComponent<CharacterController>().enabled = false;
            pawn.transform.position = new Vector3(x, y, z);
            pawn.transform.rotation = Quaternion.identity;
            pawn.GetComponent<CharacterController>().enabled = true;
        }
        else
        {
            if (pawn.GetComponent<CharacterController>() != null)
            {
                pawn.GetComponent<CharacterController>().enabled = false;
                pawn.transform.position = new Vector3(x, y, z);
                pawn.transform.rotation = Quaternion.identity;
                pawn.GetComponent<CharacterController>().enabled = true;
            }
            else
            {
                pawn.transform.position = new Vector3(x, y, z);
                pawn.transform.rotation = Quaternion.identity;
            }
        }
    }
}
