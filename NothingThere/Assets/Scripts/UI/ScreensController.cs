using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreensController : MonoBehaviour
{
    private void OffScreen()
    {
        if(gameObject.name == "GameOverScreen")
        {
            print(1);
            GameManager.Restart(false);
        }
        gameObject.SetActive(false);
    }
}
