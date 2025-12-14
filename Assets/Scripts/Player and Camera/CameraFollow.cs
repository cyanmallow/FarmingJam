using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public Rigidbody targetRb;
    public Vector3 offset;

    public float followSmoothTime = 0.15f;
    private Vector3 velocity;

    public float zoomSpeed = 10f;
    public float minFOV = 20f;
    public float maxFOV = 70f;

    private float minX;
    private float maxX;


    private Camera cam;
    private InputAction zoomAction;

    private Quaternion fixedRotation;

    void Awake()
    {
        cam = GetComponent<Camera>();
        fixedRotation = Quaternion.Euler(35f, 0f, 0f);

        zoomAction = new InputAction(
            type: InputActionType.Value,
            binding: "<Mouse>/scroll/y"
        );
        zoomAction.Enable();
    }

    void LateUpdate()
    {
        if (!targetRb) return;

        // Desired position
        Vector3 desiredPos = targetRb.position + offset;

        // Clamp BEFORE smoothing
        minX = targetRb.position.x - 10f;
        maxX = targetRb.position.x + 10f;
        desiredPos.x = Mathf.Clamp(desiredPos.x, minX, maxX);

        // Smooth follow
        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPos,
            ref velocity,
            followSmoothTime
        );

        transform.rotation = fixedRotation;

        // Zoom
        float scroll = zoomAction.ReadValue<float>();
        if (Mathf.Abs(scroll) > 0.01f)
        {
            cam.fieldOfView = Mathf.Clamp(
                cam.fieldOfView - scroll * zoomSpeed,
                minFOV,
                maxFOV
            );
        }
    }

    void OnDestroy()
    {
        zoomAction.Disable();
        zoomAction.Dispose();
    }
}
