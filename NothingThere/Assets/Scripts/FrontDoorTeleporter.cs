using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoorTeleporter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PortalTeleporter portal = transform.parent.gameObject.GetComponent<PortalTeleporter>();
        portal.PlrIsBack = false;
    }
}
