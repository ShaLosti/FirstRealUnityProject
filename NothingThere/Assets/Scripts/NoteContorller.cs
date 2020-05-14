using UnityEngine;
using UnityEngine.UI;

public class NoteContorller : MonoBehaviour
{
    [TextArea(15, 20)]
    [SerializeField] private string text;
    [SerializeField] private GameObject plr;
    [SerializeField] private MeshRenderer render;
    [SerializeField] private Color32 outlineColor;

    private Camera mainCamera;

    private RaycastHit hit;

    private void Start()
    {
        mainCamera = Camera.main;
        if (text == null) text = "";
        if (plr == null) plr = FindObjectOfType<FirstPersonController>().gameObject;
        if (render == null) render = gameObject.GetComponentInChildren<MeshRenderer>();
        if (outlineColor.a == 0)
        {
            outlineColor = new Color32(255, 148, 0, 255);
        }
    }

    public void ShowMessageOnRayCast()
    {
        hit = RayCast.CameraRayCast();
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            ShowOutline();
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                UIController.ShowMessage(text);
            }
        }
        else
        {
            HideOutline();
        }
    }

    public void ShowOutline()
    {
        foreach (var mat in render.materials)
        {
            mat.SetFloat("_Outline", .1f);
            mat.SetColor("_OutlineColor", outlineColor);
        }
    }

    public void HideOutline()
    {
        foreach (var mat in render.materials)
        {
            mat.SetFloat("_Outline", 0f);
        }
    }
}
