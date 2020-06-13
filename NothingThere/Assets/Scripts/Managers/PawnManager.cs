using UnityEngine;

public class PawnManager : MonoBehaviour
{
    public static void TeleportPawn(Transform point, GameObject pawn)
    {
        pawn.transform.position = new Vector3(point.position.x, point.position.y, point.position.z);
        pawn.transform.rotation = Quaternion.identity;
    }

    public static void TeleportPawn(Vector3 point, GameObject pawn)
    {
        pawn.transform.position = new Vector3(point.x, point.y, point.z);
        pawn.transform.rotation = Quaternion.identity;
    }
}
