using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void RunCubeLevel()
    {
        PawnManager.TeleportPawn(-334, 19, -86);
    }
    public void RunPortalLevel()
    {
        PawnManager.TeleportPawn(-269, 1.4f, -57);
    }
    public void RunBaseLevel()
    {
        PawnManager.TeleportPawn(7, 10, 9);
    }
}
