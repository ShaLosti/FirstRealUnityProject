using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControllerForNoteTriggerZone : MonoBehaviour
{
    private bool showOuteline = false;
    private bool nowOutline = false;
    private void Update()
    {
        if (showOuteline)
        {
            transform.parent.GetComponent<NoteContorller>().ShowMessageOnRayCast();
            nowOutline = true;
        }
        else if(nowOutline)
        {
            transform.parent.GetComponent<NoteContorller>().HideOutline();
            nowOutline = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        showOuteline = true;
    }

    private void OnTriggerExit(Collider other)
    {
        showOuteline = false;
    }
}
