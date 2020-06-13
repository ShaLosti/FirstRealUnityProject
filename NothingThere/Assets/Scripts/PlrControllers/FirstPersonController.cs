using UnityEngine;

public class FirstPersonController : PortalTraveller
{
    public Vector3 PreviousPosition { get; private set; }
    public bool IsPlrAllowMove { get; set; } = true;

    // Walk and run speed
    [SerializeField] private float _wayPoint = 6f;
    [SerializeField] private float _runSpeed = 12f;
    // Current move speed for rigidbody, override by _wayPoint or _runSpeed
    private float _movementSpeed;

    // Jump force Vectro3.up * __jumpForce. Override velocity
    [SerializeField] float __jumpForce = 5f;
    // If that bool variable true - plr doing jump FixedUpdate()
    private bool _jump = false;
    // Variable store distance from center of collider devided by 2. Need for rayCast wich check is grounded plr
    private float _distToGround;

    // Camera controller and mouse lock
    [SerializeField] private MouseLook _mouseLook = new MouseLook();

    // Axis for movement. Store Input.GetAxis
    private PlrInput plrInput = new PlrInput();

    // Camera perpective state. Camera rotation and movement of the plr will be different according to 2d, fps or 3d camera perspective
    // Plr state like inAir, onGround, dashing and etc.
    private readonly PlrStates states = new PlrStates();

    // Need for MovePosition. Store new position of the object
    private Vector3 _deltaPosition;

    // Camera.main
    private Camera _mainCamera;

    // Rigidbody component plr object
    private Rigidbody _rb;
    private float _slopeAngle;

    // Delegate for diffrente camera perspective
    delegate void PerspectibeStatementDelegate();

    // Set that delegates in SetPerspectiveStatementDelegate()
    PerspectibeStatementDelegate groundCheck;
    PerspectibeStatementDelegate getInputs;
    PerspectibeStatementDelegate rotateView;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
        _movementSpeed = _wayPoint;
        _distToGround = gameObject.GetComponent<CapsuleCollider>().height / 2;
        _mouseLook.Init(transform, Camera.main.transform);
        SetPlrPerspectiveState(PlrStates.PerspectiveStates.firstPerson);
    }

    private void Update()
    {
        if (IsPlrAllowMove)
        {
            groundCheck();
            getInputs();
            rotateView();
            PreviousPosition = transform.position; //for teleporter
        }
    }

    private void FixedUpdate()
    {
        if (IsPlrAllowMove)
        {
            if (_jump)
            {
                _rb.velocity += (Vector3.up * __jumpForce);
                _jump = false;
            }

            _deltaPosition = ((transform.forward * plrInput.Vertical) + (transform.right * plrInput.Horizontal)) * _movementSpeed * Time.fixedDeltaTime;
            float normaliseSlope = (_slopeAngle / 90f) * -1f;
            _deltaPosition += (_deltaPosition * normaliseSlope);

            _rb.MovePosition(_rb.position + _deltaPosition);
        }
    }

    private void SetPerspectiveStatementDelegate()
    {
        switch (states.perspectiveState)
        {
            case PlrStates.PerspectiveStates.firstPerson:
                {
                    groundCheck = GroundCheck;
                    getInputs = GetInputs;
                    rotateView = RotateView;
                    break;
                }
            case PlrStates.PerspectiveStates.Perspective:
                {
                    groundCheck = GroundCheck;
                    getInputs = GetInputs;
                    rotateView = RotateView;
                    break;
                }
            case PlrStates.PerspectiveStates.Platformer:
                {
                    groundCheck = GroundCheck;
                    getInputs = GetInputs;
                    rotateView = RotateView;
                    break;
                }
            case PlrStates.PerspectiveStates.TopDawn:
                {
                    groundCheck = GroundCheck;
                    getInputs = GetInputs;
                    rotateView = RotateView;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    private void RotateView()
    {
        //avoids the mouse looking if the game is effectively paused
        if (Mathf.Abs(Time.timeScale) < float.Epsilon) return;

        // get the rotation before it's changed
        float oldYRotation = transform.eulerAngles.y;

        _mouseLook.LookRotation(transform, _mainCamera.transform);
    }

    private void GetInputs()
    {
        plrInput.GetInputsAxis();

        if (Input.GetButtonDown("Sprint"))
            _movementSpeed = _runSpeed;
        else if (Input.GetButtonUp("Sprint"))
            _movementSpeed = _wayPoint;

        _jump = (Input.GetButtonDown("Jump") || Input.GetButtonUp("Jump")) && states.stateForMove == PlrStates.StatesForMove.onGround;
    }
    private void GroundCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, _distToGround + 0.1f))
        {
            states.stateForMove = PlrStates.StatesForMove.onGround;
            _slopeAngle = (Vector3.Angle(hit.normal, transform.forward) - 90);
        }
        else
            states.stateForMove = PlrStates.StatesForMove.inAir;
    }

    public void SetPlrStateForMove(PlrStates.StatesForMove state)
    {
        states.stateForMove = state;
    }

    public void SetPlrPerspectiveState(PlrStates.PerspectiveStates state)
    {
        states.perspectiveState = state;
        SetPerspectiveStatementDelegate();
    }

    public void EnableCursor(bool condit)
    {
        _mouseLook.SetCursorLock(!condit);
    }

    public override void Teleport(Transform fromPortal, Transform toPortal, Vector3 pos, Quaternion rot)
    {
        transform.position = pos;
        Vector3 eulerRot = rot.eulerAngles;
        Physics.SyncTransforms();
    }
}
