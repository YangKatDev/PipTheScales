using System.Collections;
using UnityEngine;

public class MovingPlatformBehaviour : MonoBehaviour
{
    public float dist = 5f;
    public float speed = 2f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        StartCoroutine(MoveScale());
    }

    IEnumerator MoveScale()
    {
        Vector3 leftTarget = startPos + Vector3.left * dist;
        Vector3 rightTarget = startPos + Vector3.right * dist;
        Vector3 currentTarget = rightTarget;

        while (true)
        {
            while (Vector3.Distance(transform.position, currentTarget) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
                yield return null;
            }
            currentTarget = (currentTarget == rightTarget) ? leftTarget : rightTarget;

            yield return new WaitForSeconds(0.5f);
        }
    }
}
