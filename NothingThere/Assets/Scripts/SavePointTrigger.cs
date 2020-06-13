using UnityEngine;

public class SavePointTrigger : MonoBehaviour
{
    [SerializeField] Vector3 savePointPosition;
    private void Start()
    {
        if(savePointPosition == Vector3.zero)
            savePointPosition = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameManager.plrGameObject)
        {
            GameManager.savePointPosition = new Vector3(savePointPosition.x, savePointPosition.y, savePointPosition.z);
        }
    }
}
