using UnityEngine;

public class MassMultiplierBehaviour : MonoBehaviour
{
    [SerializeField]
    float multiplier = 1.5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.mass *= multiplier;
        }
    }
}
