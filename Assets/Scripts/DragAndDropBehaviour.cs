using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class DragAndDropBehaviour : MonoBehaviour
{
    private Vector3 offset;
    Camera cam;
    private float zCoord;

    public InputActionReference pressAction;
    public InputActionReference mousePosition;

    public Rigidbody rb;
    private Collider col;

    private bool isDragging = false;

    void OnEnable()
    {
        pressAction.action.started += OnPress;
        pressAction.action.canceled += OnRelease;
        pressAction.action.Enable();
        mousePosition.action.Enable();
    }

    void OnDisable()
    {
        pressAction.action.started -= OnPress;
        pressAction.action.canceled -= OnRelease;
        pressAction.action.Disable();
        mousePosition.action.Disable();
    }

    private void Awake()
    {
        cam = Camera.main;
        rb.isKinematic = true;
        col = GetComponent<BoxCollider>();
    }

    public void OnPress(InputAction.CallbackContext context)
    {
        Vector2 screenPos = mousePosition.action.ReadValue<Vector2>();
        Ray ray = cam.ScreenPointToRay(screenPos);

        if (context.started)
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                isDragging = true;
                col.enabled = false;
                rb.isKinematic = true;
                zCoord = cam.WorldToScreenPoint(gameObject.transform.position).z;
                offset = gameObject.transform.position - GetMousePos();
            }
        }
    }

    public void OnRelease(InputAction.CallbackContext context)
    {
        if (isDragging)
        {
            isDragging = false;
            offset = Vector3.zero;
            col.enabled = true;
            rb.isKinematic = false;
        }
    }

    private Vector3 GetMousePos()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = zCoord;
        return cam.ScreenToWorldPoint(mousePos);
    }

    private void Update()
    {
        if (isDragging)
        {
            rb.MovePosition(GetMousePos() + offset);
        }
    }
}
