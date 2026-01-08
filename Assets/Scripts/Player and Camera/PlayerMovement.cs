//using Spine.Unity;
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class PlayerMovement : MonoBehaviour
//{
//    private Rigidbody rb;
//    public float speed = 5f;
//    private Vector2 moveInput;
//    public NPCInteractable currentNPC;
//    private FarmingManager currentFarmingTile;

//    public Transform visualRoot;
//    public float visualScale = 0.3f;

//    void Awake()
//    {
//        rb = GetComponent<Rigidbody>();
//    }
//    private void Start()
//    {
//        visualRoot.localScale = Vector3.one * visualScale;
//    }

//    void FixedUpdate()
//    {
//        // move the player
//        Vector3 dir = new Vector3(moveInput.x, 0, moveInput.y);
//        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
//    }

//    // PlayerInput calls this automatically
//    public void OnMove(InputValue value)
//    {
//        moveInput = value.Get<Vector2>();
//    }
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Transform cameraTransform;

    private Rigidbody rb;
    private Vector2 movementInput;

    public NPCInteractable currentNPC;
    private FarmingManager currentFarmingTile;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //if (cameraTransform == null)
        //    cameraTransform = Camera.main.transform;
    }

    private void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        // Get camera direction on horizontal plane
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // Translate input to world space relative to camera
        Vector3 move = camForward * movementInput.y + camRight * movementInput.x;

        rb.linearVelocity = move * speed;
    }


    // PlayerInput calls this automatically
    public void OnInteract(InputValue value)
    {
        if (currentNPC != null)
        {
            currentNPC.Interact();
        }

        // if next to a farming tile
        if (currentFarmingTile != null)
        {
            currentFarmingTile.Interact();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Farming tile
        if (other.TryGetComponent(out FarmingManager tile))
        {
            currentFarmingTile = tile;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Farming tile
        if (other.TryGetComponent(out FarmingManager tile))
        {
            if (currentFarmingTile == tile)
                currentFarmingTile = null;
        }
    }

}
