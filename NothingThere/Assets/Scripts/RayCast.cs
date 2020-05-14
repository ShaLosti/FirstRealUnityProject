using System;
using UnityEngine;

public static class RayCast
{
    public static RaycastHit CameraRayCast()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);
        return hit;
    }

    public static RaycastHit CameraRayCastScreenPoint()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);
        return hit;
    }
}
