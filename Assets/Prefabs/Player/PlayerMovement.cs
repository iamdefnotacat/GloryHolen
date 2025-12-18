using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 25f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float cameraSmoothSpeed = 8f;
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 0, -10);

    private Rigidbody2D rb;
    private Vector2 movement;
    private InputAction moveAction;
    private CircleCollider2D playerRange;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRange = GetComponent<CircleCollider2D>();
        

        moveAction = new InputAction(
            type: InputActionType.Value,
            binding: "<Gamepad>/leftStick"
        );

        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");

        moveAction.Enable();
    }

    void Update()
    {
        movement = moveAction.ReadValue<Vector2>().normalized;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void LateUpdate()
    {
        if (!playerCamera) return;

        Vector3 targetPos = transform.position + cameraOffset;

        playerCamera.transform.position = Vector3.Lerp(
            playerCamera.transform.position,
            targetPos,
            cameraSmoothSpeed * Time.deltaTime
        );
    }

    void OnDestroy()
    {
        moveAction.Disable();
    }
}
