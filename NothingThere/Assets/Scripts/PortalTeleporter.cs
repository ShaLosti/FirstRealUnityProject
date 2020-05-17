using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public GameObject plr;
    public Transform reciver;

    private bool plrIsOverlapping = false;
    private bool _plrIsBack;

    public bool PlrIsBack
    {
        get { return this._plrIsBack; }
        set { this._plrIsBack = value; }
    }

    private void OnTriggerEnter(Collider other)
    { 
        if(_plrIsBack == false)
        {
            plrIsOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        plrIsOverlapping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (plrIsOverlapping)
        {
            Vector3 portalToPlr = plr.transform.position - transform.position;
            //float dotProduct = Vector3.Dot(-transform.up, portalToPlr);
            //print(dotProduct);
            //if (dotProduct < 0f)
            //{
                float rotationDiff = Quaternion.Angle(transform.rotation, reciver.rotation);
                rotationDiff += 180;
                Camera.main.transform.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlr;
                //plr.enabled = false;
                plr.transform.position = reciver.position + positionOffset;
                //plr.enabled = true;

                plrIsOverlapping = false;
            //}
        }
    }
}
