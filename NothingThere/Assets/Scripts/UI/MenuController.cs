using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void RunCubeLevel()
    {
        PawnManager.TeleportPawn(new Vector3(-334, 19, -86), GameManager.plrGameObject);
    }
    public void RunPortalLevel()
    {
        PawnManager.TeleportPawn(new Vector3(-269, 1.4f, -57), GameManager.plrGameObject);
    }
    public void RunBaseLevel()
    {
        PawnManager.TeleportPawn(new Vector3(7, 10, 9), GameManager.plrGameObject);
    }
}
