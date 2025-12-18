using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 25f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private InputAction moveAction;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

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

    void OnDestroy()
    {
        moveAction.Disable();
    }
}
