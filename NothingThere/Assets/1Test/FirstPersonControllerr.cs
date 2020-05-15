using UnityEngine;

public class FirstPersonControllerr : MonoBehaviour
{
    [SerializeField] float walkSpeed = 3f;
    [SerializeField] float runSpeed = 12f;

    [SerializeField] float jumpForce = 5f;

    private float movementSpeed = 3f;

    private float distToGround;
    private bool isGrounded = false;
    private bool jump = false;

    private float horizontal;
    private float vertical;

    private Vector3 deltaPosition;

    private Camera mainCamera;

    private Rigidbody rb;

    [SerializeField] private MouseLook mouseLook = new MouseLook();

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        movementSpeed = walkSpeed;
        distToGround = gameObject.GetComponent<CapsuleCollider>().height / 2;
        mouseLook.Init(transform, Camera.main.transform);
    }

    private void Update()
    {
        GroundCheck();
        getInputs();
        RotateView();
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            rb.velocity += (Vector3.up * jumpForce);
            jump = false;
        }

        deltaPosition = ((transform.forward * vertical) + (transform.right * horizontal)) * movementSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + deltaPosition);    
    }

    private void RotateView()
    {
        //avoids the mouse looking if the game is effectively paused
        if (Mathf.Abs(Time.timeScale) < float.Epsilon) return;

        // get the rotation before it's changed
        float oldYRotation = transform.eulerAngles.y;

        mouseLook.LookRotation(transform, mainCamera.transform);
    }

    private void getInputs()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Sprint"))
        {
            movementSpeed = runSpeed;
        }
        else if(Input.GetButtonUp("Sprint"))
        {
            movementSpeed = walkSpeed;
        }
        jump = (Input.GetButtonDown("Jump") || Input.GetButtonUp("Jump")) && isGrounded;
    }
    private void GroundCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

}
