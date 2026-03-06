using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotationBehaviour : MonoBehaviour
{
    [SerializeField]
    Transform target;

    public float rotSpeed = 2f;
    public float distance = 10f;

    public float minAngle = -45f;
    public float maxAngle = 45f;
    private float curAngle = 0f;

    void Update()
    {
        if (target == null) return;
        transform.LookAt(target);

        float rotStep = rotSpeed * Time.deltaTime;

        if (Keyboard.current[Key.A].isPressed && curAngle > minAngle)
        {
            transform.RotateAround(target.position, Vector3.up, rotSpeed * Time.deltaTime);
            curAngle -= rotStep;
        }

        if (Keyboard.current[Key.D].isPressed && curAngle < maxAngle)
        {
            transform.RotateAround(target.position, -Vector3.up, rotSpeed * Time.deltaTime);
            curAngle += rotStep;
        }
        
    }
}
