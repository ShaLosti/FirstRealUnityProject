using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour
{
    public void UpdateCurrentHPFill(float health)
    {
        GetComponent<Slider>().value = health;
    }

    public void UpdateMaxHPFill(float health)
    {
        GetComponent<Slider>().maxValue = health;
    }
}
