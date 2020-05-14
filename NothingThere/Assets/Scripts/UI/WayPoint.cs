using UnityEngine;
using UnityEngine.UI;

public class WayPoint : MonoBehaviour
{
    private Camera mainCamera;
    private GameObject targetPointForWayVisual;
    private Image wayImg;

    public GameObject TargetPointForWayVisual 
    { 
        get => targetPointForWayVisual; 
        set
        {
            targetPointForWayVisual = value;
            if (value == null)
            {
                ShowWayPoint(false);
            }
            else
            {
                calcWayPointPosition();
                ShowWayPoint(true);                           
            }           
        }
    }

    public void IdentifyObjects()
    {
        if (wayImg == null)
        {
            wayImg = gameObject.GetComponentInChildren<Image>();
        }
        mainCamera = Camera.main;
    }
    void Update()
    {
        if (targetPointForWayVisual != null)
        {
            calcWayPointPosition();
        }
    }
    private void calcWayPointPosition()
    {
        float minX = wayImg.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = wayImg.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        Vector2 pos = mainCamera.WorldToScreenPoint(targetPointForWayVisual.transform.position);

        // Offset - Vectro3 переменная, позволяющая поднимать чуть выше или перемещать метку вокруг объектана постоянном расстоянии
        //Vector2 pos = mainCamera.WorldToScreenPoint(targetPointForWayVisual.transform.position + Offset);

        if (Vector3.Dot((targetPointForWayVisual.transform.position - mainCamera.transform.position), mainCamera.transform.forward) < 0)
        {
            if (pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        gameObject.transform.position = pos;

        //meter - переменная типа Text позволяет отображать расстояние до объекта
        //meter.text = ((int)Vector3.Distance(target.position, transform.position)).ToString() + "m";
    }
    public void SetNewWaypointImg(Sprite sprite)
    {
        wayImg.sprite = sprite;
    }

    public void ShowWayPoint(bool cond)
    {
        gameObject.SetActive(cond);
    }
}
