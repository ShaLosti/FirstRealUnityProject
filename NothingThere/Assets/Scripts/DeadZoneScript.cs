using UnityEngine;

public class DeadZoneScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameManager.plrGameObject)
            GameManager.GameOver();
    }
}
