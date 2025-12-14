using Spine.Unity;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    private Vector2 moveInput;
    public NPCInteractable currentNPC;

    public Transform visualRoot;
    public float visualScale = 0.3f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        visualRoot.localScale = Vector3.one * visualScale;
    }

    void FixedUpdate()
    {
        // move the player
        Vector3 dir = new Vector3(moveInput.x, 0, moveInput.y);
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
    }

    // PlayerInput calls this automatically
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // PlayerInput calls this automatically
    public void OnInteract(InputValue value)
    {
        if (currentNPC != null)
        {
            currentNPC.Interact();
        }
    }
}
