using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GameManager.plrGameObject)
        {
            GameManager.savePointPosition = transform;
        }
    }
}
