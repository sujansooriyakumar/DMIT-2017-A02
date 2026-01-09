using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public InputAction moveInput;
    private Vector3 movementDirection = Vector3.zero;
    public float moveSpeed = 1.0f;

    void Start()
    {
        moveInput.Enable();
        moveInput.performed += GetMoveVector;
        moveInput.canceled += GetMoveVector;

    }

    public void GetMoveVector(InputAction.CallbackContext context)
    {
        var tmp = context.ReadValue<Vector2>();
        movementDirection = new Vector3(tmp.x, 0, tmp.y);
    }

    public void Update()
    {
        transform.position += movementDirection * moveSpeed * Time.deltaTime;
    }


}
