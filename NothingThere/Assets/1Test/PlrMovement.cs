using UnityEngine;

public class PlrMovement : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;

    [SerializeField] private float walkSpeed, runSpeed;
    [SerializeField] private float runBuildup;
    [SerializeField] private KeyCode runKey;

    private float movementSpeed;

    [SerializeField] private float slopeForce;
    [SerializeField] private float slopeForceRayLength;

    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;

    private CharacterController plrCharController;
    private bool isInAir;

    private void Awake()
    {
        plrCharController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        if (Input.GetKeyDown(jumpKey) && !isInAir) Jump();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis(horizontalInputName); //SimpleMove add Time.DeltaTime automaticly
        float verticalInput = Input.GetAxis(verticalInputName); //SimpleMove add Time.DeltaTime automaticly

        Vector3 forwardMovement = transform.forward * verticalInput;
        Vector3 rightMovement = transform.right * horizontalInput;

        SetMoveSpeed();

        plrCharController.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1f) * movementSpeed); //SimpleMove add Time.DeltaTime automaticly
    
        if((verticalInput != 0 || horizontalInput != 0) && OnSlope())
        {
            plrCharController.Move(Vector3.down * plrCharController.height / 2 * slopeForce * Time.deltaTime);
        }
        
    }

    private void SetMoveSpeed()
    {        
        if (Input.GetKey(runKey))
        {
            movementSpeed = Mathf.Lerp(movementSpeed, runSpeed, Time.deltaTime * runBuildup);
        }
        else
        {
            movementSpeed = Mathf.Lerp(movementSpeed, walkSpeed, Time.deltaTime * runBuildup);
        }
    }

    private bool OnSlope()
    {
        if (isInAir)
        {
            return false;
        }

        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, plrCharController.height / 2 * slopeForceRayLength))
        {
            if(hit.normal != Vector3.up)
            {
                return true;
            }
        }
        return false;
    }

    private void Jump()
    {
        plrCharController.slopeLimit = 90f;
        plrCharController.Move(Vector3.up * jumpMultiplier * Time.deltaTime);
        plrCharController.slopeLimit = 45f;
    }
}
