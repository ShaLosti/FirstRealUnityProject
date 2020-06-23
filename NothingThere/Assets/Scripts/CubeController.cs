using UnityEngine;

public abstract class CubeController : MonoBehaviour
{
    [SerializeField] protected Color32 newColor;

    protected Renderer rend;
    private Color32 oldColor;
    private GameObject plr;
    
    //protected Animator animator;

    public void ResetCubeColor()
    {
        rend.material.color = oldColor;
        //animator.SetBool("isUsed", false);
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == plr)
        {
            //animator.SetBool("isUsed", true);
            GameManager.cubesForReset.Add(gameObject);
            ChangeColor();
        }
    }

    protected void ChangeColor()
    {
        rend.material.color = newColor;
    }

    protected void Start()
    {
        //plr = FindObjectOfType<FirstPersonController>().gameObject;
        //animator = transform.parent.GetComponent<Animator>();

        rend = transform.GetComponent<Renderer>();
        oldColor = rend.material.color;
        if (plr == null) plr = GameManager.plrGameObject;
        if (plr == null) plr = FindObjectOfType<FirstPersonController>().gameObject;
    }
}
