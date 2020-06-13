using DG.Tweening;
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
        transform.DOMoveY(transform.position.y + 4f, 2);
    }
}
