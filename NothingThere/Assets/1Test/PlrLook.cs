using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlrLook : MonoBehaviour
{
    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensetivity;

    [SerializeField] private Transform plrBody;

    private float xAxisClamp;
    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0f;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensetivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if(xAxisClamp > 90f)
        {
            xAxisClamp = 90f;
            mouseY = 0;
            ClampXAxisRotationToValue(270f);
        }

        if (xAxisClamp < -90f)
        {
            xAxisClamp = -90f;
            mouseY = 0;
            ClampXAxisRotationToValue(90f);
        }

        transform.Rotate(Vector3.left * (mouseY)); //we change X value, so Vector3.left = (-1,0,0)
        plrBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
