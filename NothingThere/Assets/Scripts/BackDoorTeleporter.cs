using UnityEngine;

public class BackDoorTeleporter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PortalTeleporter portal = transform.parent.gameObject.GetComponent<PortalTeleporter>();
        portal.PlrIsBack = true;
    }
}
