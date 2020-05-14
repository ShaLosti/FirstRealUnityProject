using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plrAtached : MonoBehaviour
{
    public GameObject AtachToPlatform;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == AtachToPlatform)
        {
            AtachToPlatform.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        AtachToPlatform.transform.parent = null;
    }
}
