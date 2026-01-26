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
    private SellingManger currentCrate;

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

        // if next to a selling crate
        if (currentCrate != null)
        {
            currentCrate.Interact();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Farming tile
        if (other.TryGetComponent(out FarmingManager tile))
        {
            currentFarmingTile = tile;
        }

        // Selling crate
        if (other.TryGetComponent(out SellingManger crate))
        {
            currentCrate = crate;
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

        // Selling crate
        if (other.TryGetComponent(out SellingManger crate))
        {
            if (currentCrate == crate)
                currentCrate = null;
        }
    }

}
