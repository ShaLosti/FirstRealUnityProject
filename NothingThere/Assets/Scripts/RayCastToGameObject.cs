using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RayCastToGameObject : MonoBehaviour
{   
    [SerializeField] private TMPro.TextMeshProUGUI scoreTextForUi;
    [SerializeField] private List<Rigidbody> gameObjectToAttached;

    private int power = 10;
    private RaycastHit hit;
    private Camera mainCamera;

    private void IdentifyIbjects()
    {
        if (scoreTextForUi == null) scoreTextForUi = GameManager.FindObjectFromParentObject(FindObjectOfType<UIController>().gameObject, "TextScore").GetComponent<TMPro.TextMeshProUGUI>(); ;
    }

    private void Start()
    {
        IdentifyIbjects();
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        hit = RayCast.CameraRayCast();
        if (hit.collider != null && (gameObjectToAttached.Contains(hit.collider.attachedRigidbody) || hit.collider.tag == "PushRigidByClick"))
        {
            pushRigidBody(hit.collider.attachedRigidbody);
        }
    }
    private void pushRigidBody(Rigidbody rb)
    {
        rb.AddForceAtPosition(mainCamera.transform.forward * power, hit.point, ForceMode.Impulse);
        UIController.AddScoreUIForFPP(1);
    }
}
