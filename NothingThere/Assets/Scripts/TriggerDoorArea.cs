using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.current.DoorwayTriggerEnter();
    }
}
