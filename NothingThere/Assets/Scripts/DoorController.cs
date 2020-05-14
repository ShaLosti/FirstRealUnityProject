using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private void Start()
    {
        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;       
    }

    private void OnDoorwayOpen()
    {
        transform.Translate(transform.position.x, transform.position.y + 4f, transform.position.z);
    }
}
