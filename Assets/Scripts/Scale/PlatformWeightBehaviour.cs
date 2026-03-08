using UnityEngine;
using System.Collections.Generic;
public class PlatformWeightBehaviour : MonoBehaviour
{
    public ScaleBalancingBehaviour scale;
    public bool isLeftPlatform;
    public float boxSize = 0.5f;


    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position + Vector3.up *(boxSize / 2), new Vector3(boxSize, boxSize, boxSize), transform.rotation);

        float totalMass = 0;
        foreach (var col in colliders)
        {
            if (col.transform.IsChildOf(scale.transform) || col.gameObject == scale.gameObject)
            {
                continue;
            }

            Rigidbody rb = col.attachedRigidbody;
            if (rb != null) 
            { 
                totalMass += rb.mass; 
            }
        }

        if (isLeftPlatform) scale.leftWeight = totalMass;
        else scale.rightWeight = totalMass;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        Gizmos.matrix = Matrix4x4.TRS(transform.position + Vector3.up * 0.5f, transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(0.5f, 0.5f, 0.5f));
    }
}
