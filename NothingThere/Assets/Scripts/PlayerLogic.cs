using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private HpController hp;
    private void Start()
    {
        hp = GetComponent<HpController>();
        if (GameManager.savePointPosition == null)
            GameManager.savePointPosition = transform;
    }
    
}
